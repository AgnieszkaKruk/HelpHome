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
    public class WindowsCleaningServices : IWindowsCleaningServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public WindowsCleaningServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public WindowsCleaningDto GetById(int seekerId, int offerId)
        {
            _logger.Info($"WindowsCleaning offer with id: {offerId} GET action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFpundExeption
            }
            var offer = _context.WindowsCleaningOffers.FirstOrDefault(u => u.Id == offerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                return null; ///throw new NotFoundExeption
            }

            var offerDto = _mapper.Map<WindowsCleaningDto>(offer);
            return offerDto;
        }

        public List<WindowsCleaningDto> GetAll(int seekerId)
        {
            _logger.Info($"All CWindowsCleaning offers from Seeker with id: {seekerId} GET All action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFoundExeption
            }

            var allOffers = seeker.WindowsCleaningOffers;

            var allOffersDto = _mapper.Map<List<WindowsCleaningDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateWindowsCleaningDto dto, int seekerId)
        {
            _logger.Info($"New WindowsCleaning offer from Seeker with id: {seekerId} was created");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                return 0; ///throw new NotFpundExeption
            }
            var offer = _mapper.Map<WindowsCleaning>(dto);
            offer.SeekerId = seekerId;
            _context.WindowsCleaningOffers.Add(offer);
            seeker.WindowsCleaningOffers.Add(offer);
            _context.SaveChanges();
            return offer.Id;
        }
    }
}
