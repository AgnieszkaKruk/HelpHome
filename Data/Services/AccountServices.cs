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
            var seeker = _context.Seekers.Include(s => s.Role).FirstOrDefault(s => s.Email == dto.Email);
            var offerent = _context.Oferrents.Include(o => o.Role).FirstOrDefault(o => o.Email == dto.Email);

            if (seeker is null && offerent is null)
            {
                throw new BadRequestException("Invalid login or password");
            }
            else
            {
                if (seeker != null)

                {
                    var seekerResult = _passwordHasherSeeker.VerifyHashedPassword(seeker, seeker.PasswordHash, dto.Password);
                    if (seekerResult == PasswordVerificationResult.Failed)
                    {
                        throw new BadRequestException("Invalid login or password");
                    }
                    else
                    {
                        var claimsSeeker = new List<Claim>();

                        claimsSeeker.Add(new Claim(ClaimTypes.NameIdentifier, seeker.Id.ToString()));
                        claimsSeeker.Add(new Claim(ClaimTypes.Name, seeker.Name));
                      //  claimsSeeker.Add(new Claim(ClaimTypes.Role, seeker.Role.Name));
                    

                        var keySeeker = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSeetings.JwtKey));
                        var cred = new SigningCredentials(keySeeker, SecurityAlgorithms.HmacSha256);
                        var expires = DateTime.Now.AddDays(_authenticationSeetings.JwtExpireDays);

                        var tokenSeeker = new JwtSecurityToken(_authenticationSeetings.JwtIssuer, _authenticationSeetings.JwtIssuer,
                            claimsSeeker,
                            expires: expires,
                            signingCredentials: cred);

                        var tokenHandler = new JwtSecurityTokenHandler();
                        return tokenHandler.WriteToken(tokenSeeker);
                    }

                }
                throw new BadRequestException("Invalid login or password");
                if (offerent != null)
                {
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
                       new Claim(ClaimTypes.Role, offerent.Role.Name),
                    };

                        var keyOfferent = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSeetings.JwtKey));
                        var cred = new SigningCredentials(keyOfferent, SecurityAlgorithms.HmacSha256);
                        var expires = DateTime.Now.AddDays(_authenticationSeetings.JwtExpireDays);

                        var tokenOfferent = new JwtSecurityToken(_authenticationSeetings.JwtIssuer, _authenticationSeetings.JwtIssuer,
                            claimsOfferent,
                            expires: expires,
                            signingCredentials: cred
                            );
                        var tokenHandler = new JwtSecurityTokenHandler();
                        return tokenHandler.WriteToken(tokenOfferent);
                    }
                }
                throw new BadRequestException("Invalid login or password");
            }
        }
    }
}

