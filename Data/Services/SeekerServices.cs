using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SeekerServices : ISeekerServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        public SeekerServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;

        }

        public IEnumerable<SeekerDto> GetAllWithOffers()
        {
            var seekers = _context.Seekers.ToList(); // do poprawienia, dodac ich oferty

            var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
            return seekersDto;
        }

        public IEnumerable<SeekerDto> GetAll()
        {
            var seekers = _context.Seekers.ToList();

            var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
            return seekersDto;
        }

        public SeekerDto GetById(int id)
        {
            var seeker = _context.Seekers.FirstOrDefault(s => s.Id == id);
            var seekerDto = _mapper.Map<SeekerDto>(seeker);
            return seekerDto;


        }

        public bool Delete(int id)
        {
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == id);
            if (seeker is null) return false;
            else
            {
                _context.Seekers.Remove(seeker);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Update(CreateSeekerDto dto, int id)
        {
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == id);
            if (seeker is null) return false;
            else
            {
                seeker.Name = dto.Name;
                seeker.Email = dto.Email;
                seeker.PhoneNumber = dto.PhoneNumber;

                _context.SaveChanges();
                return true;
            }

        }

        public int CreateSeeker(CreateSeekerDto dto)
        {

            var seeker = _mapper.Map<Seeker>(dto);
            _context.Seekers.Add(seeker);
            _context.SaveChanges();
            return seeker.Id;
        }
    }
}

