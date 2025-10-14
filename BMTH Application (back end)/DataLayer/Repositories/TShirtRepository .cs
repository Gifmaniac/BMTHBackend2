using Contracts.Enums.Store;
using Contracts.Interfaces;
using Domain.Domains.Store.TShirts;


namespace DataLayer.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly List<TShirt> _tShirts;

        public List<TShirt> GetShirtsByGender(Genders? gender = null)
        {
            IEnumerable<TShirt> getTShirts = _tShirts;

            if (gender.HasValue)
            {
                getTShirts = getTShirts
                    .Where(tShirt => tShirt.Gender == gender.Value || tShirt.Gender == Genders.Unisex);
            }

            return getTShirts.ToList();
        }
    }
}
