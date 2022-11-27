using AutoMapper;
using Domain.Models;
using HelpHome.Entities;
using HelpHomeApi;
using Microsoft.AspNetCore.Identity;

namespace Data.Services
{
    public class AccountServices : IAccountServices
    {

        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        private readonly IPasswordHasher<Seeker> _passwordHasher;

        public AccountServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger, IPasswordHasher<Seeker> passwordHasher)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
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
            var newSeekerPassword = _passwordHasher.HashPassword(newSeeker, dto.Password);
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
            _context.Oferrents.Add(newOfferent);
            _context.SaveChanges();
        }







    }
}

