using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHomeApi;
using Data.Exceptions;

using System.Data.Entity;

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
            var seekers = _context.Seekers.Include(x=>x.CleaningOffers).Include(x=>x.WindowsCleaningOffers).Include(x=>x.CarpetWaschingOffers);
            if (seekers is null)
            {
                throw new NotFoundException("Seekers not found");
            }
            else
            {
                var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
                return seekersDto;
            }
        }

        public IEnumerable<SeekerDto> GetAll()
        {
            _logger.Info($"Seekers GET All action invoked");
            var seekers = _context.Seekers.Include(x => x.CleaningOffers).Include(x => x.WindowsCleaningOffers).Include(x => x.CarpetWaschingOffers).ToList();
            if (seekers is null)
            {
                throw new NotFoundException("Seekers not found");
            }
            else
            {
                var seekersDto = _mapper.Map<List<SeekerDto>>(seekers);
                return seekersDto;
            }

        }

        public SeekerDto GetById(int id)
        {
            _logger.Info($"Seeker with id: {id} GET action invoked");
            var seeker = _context.Seekers.Include(x => x.CleaningOffers).Include(x => x.WindowsCleaningOffers).Include(x => x.CarpetWaschingOffers).FirstOrDefault(s => s.Id == id);
            if (seeker is null)
            {
                throw new NotFoundException("Seeker is not found");
            }
            else
            {
                var seekerDto = _mapper.Map<SeekerDto>(seeker);
                return seekerDto;
            }

        }

        public void Delete(int id)
        {
            _logger.Warn($"Seeker with id: {id} DELETE action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == id);
            if (seeker is null)
            {
                throw new NotFoundException("Seeker is not found");
            }
            else
            {
                _context.Seekers.Remove(seeker);
                _context.SaveChanges();
                
            }
        }

        public void Update(CreateSeekerDto dto, int id)
        {
            _logger.Info($"Seeker with id: {id} UPDATE action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == id);
            if (seeker is null)
            {
                throw new NotFoundException("Seeker is not found");
            }
            else
            {
                seeker.Name = dto.Name;
                seeker.Email = dto.Email;
                seeker.PhoneNumber = dto.PhoneNumber;

                _context.SaveChanges();
                
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

