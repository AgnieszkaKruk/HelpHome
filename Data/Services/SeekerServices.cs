﻿using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHomeApi;
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
        private readonly ILog _logger;
        public SeekerServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;

        }

        public IEnumerable<SeekerDto> GetAllWithOffers()
        {
            _logger.Info($"Seekers GET AllWithOffers action invoked");
            var seekers = _context.Seekers.ToList(); 

            var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
            return seekersDto;
        }

        public IEnumerable<SeekerDto> GetAll()
        {
            _logger.Info($"Seekers GET All action invoked");
            var seekers = _context.Seekers.ToList();

            var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
            return seekersDto;
        }

        public SeekerDto GetById(int id)
        {
            _logger.Info($"Seeker with id: {id} GET action invoked");
            var seeker = _context.Seekers.FirstOrDefault(s => s.Id == id);
            var seekerDto = _mapper.Map<SeekerDto>(seeker);
            return seekerDto;


        }

        public bool Delete(int id)
        {
            _logger.Warn($"Seeker with id: {id} DELETE action invoked");
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
            _logger.Info($"Seeker with id: {id} UPDATE action invoked");
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
            _logger.Info($"New Seeker with id:{dto.Id} is created");
            var seeker = _mapper.Map<Seeker>(dto);
            _context.Seekers.Add(seeker);
            _context.SaveChanges();
            return seeker.Id;
        }
    }
}

