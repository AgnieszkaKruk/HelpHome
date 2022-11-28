using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHomeApi;
using HelpHomeApi.Exeptions;
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
        private readonly ILog  _logger;
        public OfferentServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<OfferentDto> GetAllWithPreferences() 
        {
            var offerents = _context.Oferrents.ToList();
            if (offerents is null)
            {
                throw new NotFoundExeption("Offerents not found");
            }
            else
            {
                var offerentsDto = _mapper.Map<List<OfferentDto>>(offerents);
                return offerentsDto;
            }
        }

        public IEnumerable<OfferentDto> GetAll()
        {
            _logger.Info($"Offerents GET All action invoked");
            var offerents = _context.Oferrents.ToList();
            if (offerents is null)
            {
                throw new NotFoundExeption("Offerents not found");
            }
            else
            {
                var offerentsDto = _mapper.Map<List<OfferentDto>>(offerents);
                return offerentsDto;
            }
        }

        public OfferentDto GetById(int id)
        {
            _logger.Info($"Offerent with id: {id} GET action invoked");
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);
            if (offerent is null)
            {
                throw new NotFoundExeption("Offerent is not found");
            }
            else
            {
                var offerentDto = _mapper.Map<OfferentDto>(offerent);
                return offerentDto;
            }

        }

        public void Delete(int id)
        {
            _logger.Warn($"Offerent with id: {id} DELETE action invoked");
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);
            if (offerent is null)
            {
                throw new NotFoundExeption("Offerent is not found");
            }
            else
            {
                _context.Oferrents.Remove(offerent);
                _context.SaveChanges();
                
            }
        }

        public void Update(CreateOfferentDto dto, int id )
        {
            _logger.Info($"Offerent with id: {id} UPDATE action invoked");
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == id);
            if (offerent is null)
            {
                throw new NotFoundExeption("Offerent is not found");
            }
            else
            {
                offerent.Name = dto.Name;
                offerent.Email = dto.Email;
                offerent.PhoneNumber = dto.PhoneNumber;

                _context.SaveChanges();
                
            }

        }

        public int CreateOfferent(CreateOfferentDto dto)
        {
            _logger.Info($"New Offerent with id:{dto.Id} is created");
            var offerent = _mapper.Map<Offerent>(dto);
            _context.Oferrents.Add(offerent);
            _context.SaveChanges();
            return offerent.Id;
        }
    }
}

