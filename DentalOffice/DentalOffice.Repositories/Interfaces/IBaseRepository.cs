namespace DentalOffice.Repositories.Interfaces
{
    public interface IBaseRepository<Tkey, Tmodel, Tsearch, Tdb> where Tmodel : class where Tsearch : class where Tdb : class
    {
        Task<List<Tmodel>> GetAll(Tsearch? searchRequest);
        Task<Tmodel?> GetById(Tkey id);
        Task<Tmodel> Create(Tmodel model);
        Task<Tmodel> Update(Tkey id, Tmodel model);
        Task<Tmodel?> Delete(Tkey id);
    }
}
