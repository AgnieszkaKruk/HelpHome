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
    public class OfferentServices : IOfferentServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        public OfferentServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;

        }

        public IEnumerable<OfferentDto> GetAllWithPreferences() //bool w parametrach 
        {
            var offerents = _context.Oferrents.Include(r => r.Addresses).ToList(); // do poprawienia

            var offerentsDto = _mapper.Map<List<OfferentDto>>(offerents);
            return offerentsDto;
        }

        public IEnumerable<OfferentDto> GetAll()
        {
            var offerents = _context.Oferrents.Include(r => r.Addresses).ToList(); 

            var offerentsDto = _mapper.Map<List<OfferentDto>>(offerents);
            return offerentsDto;
        }

        public OfferentDto GetById(int id)
        {
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);

            var offerentDto = _mapper.Map<OfferentDto>(offerent);
            return offerentDto;


        }

        public bool Delete(int id)
        {
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);
            if (offerent is null) return false;
            else
            {
                _context.Oferrents.Remove(offerent);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Update(CreateOfferentDto dto, int id )
        {
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);
            if (offerent is null) return false;
            else
            {
                offerent.Name = dto.Name;
                offerent.Email = dto.Email;
                offerent.PhoneNumber = dto.PhoneNumber;

                _context.SaveChanges();
                return true;
            }

        }

        public int CreateOfferent(CreateOfferentDto dto)
        {

            var offerent = _mapper.Map<Offerent>(dto);
            _context.Oferrents.Add(offerent);
            _context.SaveChanges();
            return offerent.Id;
        }
    }
}

