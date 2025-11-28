using BloodBank.Domain.Entities;

namespace BloodBank.Domain.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation?> GetById(int id);
        Task<int> Add(Donation donor);
        Task Update(Donation donor);
        Task Delete(int id);
        Task<List<Donation>> GetLast30Days();
    }
}
