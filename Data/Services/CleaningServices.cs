﻿using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using HelpHomeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CleaningServices : ICleaningServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public CleaningServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public CleaningDto GetById(int seekerId, int offerId)
        {
            _logger.Info($"Cleaning offer with id: {offerId} GET action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFpundExeption
            }
            var offer = _context.CleaningOffers.FirstOrDefault(u => u.Id == offerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                return null; ///throw new NotFoundExeption
            }

            var offerDto = _mapper.Map<CleaningDto>(offer);
            return offerDto;
        }

        public List<CleaningDto> GetAll(int seekerId)
        {
            _logger.Info($"All CarpetWashing offers from Seeker with id: {seekerId} GET All action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFoundExeption
            }

            var allOffers = seeker.CleaningOffers;

            var allOffersDto = _mapper.Map<List<CleaningDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateCleaningDto dto, int seekerId)
        {
            _logger.Info($"New Cleaning offer from Seeker with id: {seekerId} was created");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                return 0; ///throw new NotFpundExeption
            }
            var offer = _mapper.Map<Cleaning>(dto);
            offer.SeekerId = seekerId;
            _context.CleaningOffers.Add(offer);
            seeker.CleaningOffers.Add(offer);
            _context.SaveChanges();
            return offer.Id;
        }
    }
}
