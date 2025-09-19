using Contracts.Interfaces;


namespace DataLayer.Interfaces
{
    public interface ITShirtRepository
    {
        List<TShirt> GetMaleShirts();
        List<TShirt> GetWomenShirts();
        List<TShirt> GetUnisexShirts()
    }
}
