﻿using AutoMapper;
using Data;
using Domain.Entities;
using Domain.Models;
using HelpHome.Entities.OfferTypes;
using HelpHomeApi;
using HelpHomeApi.Exeptions;
using System.Data.Entity;

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
                throw new NotFoundExeption("Seeker is not found");
            }
            var offer = _context.WindowsCleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.SeekerId == seekerId && x.Id == offerId);
            if (offer is null )
            {
                throw new NotFoundExeption("Offer is not found");
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
                throw new NotFoundExeption("Seeker is not found");
            }

            var allOffers = _context.WindowsCleaningOffers.Include(s => s.Address).Where(u => u.SeekerId == seekerId);

            var allOffersDto = _mapper.Map<List<WindowsCleaningDto>>(allOffers);
            return allOffersDto;
        }
        public List<OfferDto> GetAllOffers()
        {
            _logger.Info($"All CarpetWashing offers GET All action invoked");

            
            var allOffers = _context.WindowsCleaningOffers.Include(x => x.Address.City);

            var allOffersDto = _mapper.Map<List<OfferDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateWindowsCleaningDto dto, int seekerId)
        {
            _logger.Info($"New WindowsCleaning offer from Seeker with id: {seekerId} was created");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                throw new NotFoundExeption("Seeker is not found");
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

