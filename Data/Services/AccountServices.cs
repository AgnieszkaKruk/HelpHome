using AutoMapper;
using Data.Exceptions;
using Domain.Models;
using HelpHome.Entities;
using HelpHomeApi;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Data.Services
{
    public class AccountServices : IAccountServices
    {

        private readonly HelpHomeDbContext _context;
        private readonly IPasswordHasher<Seeker> _passwordHasherSeeker;
        private readonly IPasswordHasher<Offerent> _passwordHasherOfferent;
        private readonly AuthenticationSettings _authenticationSeetings;

        public AccountServices(HelpHomeDbContext helpHomeDbContext, IPasswordHasher<Seeker> passwordHasherSeeker, IPasswordHasher<Offerent> passwordHasherOfferent, AuthenticationSettings authenticationSettings)
        {
            _context = helpHomeDbContext;
            _passwordHasherOfferent = passwordHasherOfferent;
            _passwordHasherSeeker = passwordHasherSeeker;
            _authenticationSeetings = authenticationSettings;
        }

        public void RegisterSeeker(RegisterSeekerDto dto)
        {
            var newSeeker = new Seeker()
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleId = dto.RoleId,

                PhoneNumber = dto.PhoneNumber,


            };
            var newSeekerPassword = _passwordHasherSeeker.HashPassword(newSeeker, dto.Password);
            newSeeker.PasswordHash = newSeekerPassword;
            _context.Seekers.Add(newSeeker);
            _context.SaveChanges();
        }

        public void RegisterOfferent(RegisterOfferentDto dto)
        {
            var newOfferent = new Offerent()
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleId = dto.RoleId,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = dto.Password

            };
            var newOfferentPassword = _passwordHasherOfferent.HashPassword(newOfferent, dto.Password);
            newOfferent.PasswordHash = newOfferentPassword;
            _context.Oferrents.Add(newOfferent);
            _context.SaveChanges();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var seeker = _context.Seekers.Include("Role").FirstOrDefault(s => s.Email == dto.Email);

            var offerent = _context.Oferrents.Include(o => o.Role).FirstOrDefault(o => o.Email == dto.Email);

            if (seeker is null && offerent is null)
            {
                throw new BadRequestException("Invalid login or password");
            }
            else
            {
                if (seeker != null && offerent == null)
                {
                    var seekerRole = _context.Roles.FirstOrDefault(x => x.Id == seeker.RoleId);
                    var seekerResult = _passwordHasherSeeker.VerifyHashedPassword(seeker, seeker.PasswordHash, dto.Password);
                    if (seekerResult == PasswordVerificationResult.Failed)
                    {
                        throw new BadRequestException("Invalid login or password");
                    }
                    else
                    {
                        var claimsSeeker = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, seeker.Id.ToString()),
                            new Claim(ClaimTypes.Name, seeker.Name),
                            new Claim(ClaimTypes.Role,$"{seekerRole.Name}")
                        };
                        return MakeToken(claimsSeeker);
                    }
                    throw new BadRequestException("Invalid login or password");
                }

                if (offerent != null && seeker == null)
                {
                    var offerentRole = _context.Roles.FirstOrDefault(x => x.Id == offerent.RoleId);
                    var offerentResult = _passwordHasherOfferent.VerifyHashedPassword(offerent, offerent.PasswordHash, dto.Password);

                    if (offerentResult == PasswordVerificationResult.Failed)
                    {
                        throw new BadRequestException("Invalid login or password");
                    }
                    else
                    {
                        var claimsOfferent = new List<Claim>()
                    {
                       new Claim(ClaimTypes.NameIdentifier,offerent.Id.ToString()),
                       new Claim(ClaimTypes.Name, offerent.Name),
                       new Claim(ClaimTypes.Role, $"{offerentRole.Name}"),
                    };
                        return MakeToken(claimsOfferent);
                    }
                }
                throw new BadRequestException("Invalid login or password");
            }
        }
        private string MakeToken(List<Claim> claims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSeetings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSeetings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSeetings.JwtIssuer, _authenticationSeetings.JwtIssuer,
                claims: claims,
                expires: expires,
                signingCredentials: cred
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }

    }
}

