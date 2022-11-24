using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using Microsoft.EntityFrameworkCore;
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
        public WindowsCleaningServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;

        }


        public WindowsCleaningDto GetById(int seekerId, int offerId)
        {
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFpundExeption
            }
            var offer = _context.WindowsCleaningOffers.Include(s=>s.Address).FirstOrDefault(u => u.Id == seekerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                return null; ///throw new NotFoundExeption
            }

            var offerDto = _mapper.Map<WindowsCleaningDto>(offer);
            return offerDto;
        }

        public List<WindowsCleaningDto> GetAll(int seekerId)
        {
            var seeker = _context.Seekers.Include(x=>x.WindowsCleaningOffers).FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFoundExeption
            }

            var allOffers = seeker.WindowsCleaningOffers.ToList();

            var allOffersDto = _mapper.Map<List<WindowsCleaningDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateWindowsCleaningDto dto, int seekerId)
        {

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

