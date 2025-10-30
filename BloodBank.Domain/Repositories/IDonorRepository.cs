using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAll();
        Task<Donor?> GetById(int id);
        Task<int> Add(Donor donor);
        Task Update(Donor donor);
        Task Delete(int id);
    }
}
