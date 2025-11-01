using BloodBank.Domain.Entities;
namespace BloodBank.Domain.Repositories
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAll();
        Task<BloodStock?> GetById(int id);
        Task<int> Add(BloodStock bloodStock);
        Task Update(BloodStock bloodStock);
        Task Delete(int id);
    }
}
