using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Shirts;
using BusinessLayer.Exceptions;
using BusinessLayer.Helper.Validator.Store;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.DALMapper.StoreItems.Common;
using BusinessLayer.Mapper.DALMapper.StoreItems.TShirts;
using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLayer.Services
{
    public class TShirtService : ITShirtService
    {
        private readonly ITShirtRepository _tShirtRepository;
        private readonly ILogger<ITShirtService> _logger;

        public TShirtService(ITShirtRepository repo, ILogger<ITShirtService> logger)
        {
            _tShirtRepository = repo;
            _logger = logger;
        }

        public List<StoreItemOverview> GetTShirtsByGender(string? gender)
        {
            var validatedGender = MerchandiseValidator.ValidateGender(gender);
            var models = _tShirtRepository.GetTShirtOverviewByGender(validatedGender);

            if (models == null || !models.Any()) 
            { 
                throw new NotFoundException("No T-Shirts have been found for the selected gender");
            }

            return StoreItemOverviewDalMapper.ToOverviewDomainList(models);
        }

        public TShirt? GetShirtById(int? id)
        {
            TShirtModel? tShirtId = _tShirtRepository.GetById(id);

            if (tShirtId == null ) 
            {
                throw new NotFoundException($"No T-shirt found with ID {id}.");
            } 
            return TShirtDalMapper.ToDomain(tShirtId);
        }
    }
}
