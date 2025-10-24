using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _context;

        public DonorRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donor>> GetAll()
        {
            var donors = await _context.Donors.ToListAsync();

            return donors;
        }

        public async Task<Donor> GetById(int id)
        {
            var donor = await _context.Donors
                .FirstOrDefaultAsync(d => d.Id == id);

            return donor;
        }

        public async Task<int> Add(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return donor.Id;
        }

        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var donor = _context.Donors.FirstOrDefault(d => d.Id == id);

            if (donor != null)
                return;

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }
    }
}
