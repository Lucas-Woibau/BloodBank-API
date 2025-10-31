using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _context;

        public DonationRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donation>> GetAll()
        {
            var donations = await _context.Donations
                .Include(d => d.Donor)
                .ToListAsync();

            return donations;
        }

        public async Task<Donation?> GetById(int id)
        {
            var donation = await _context.Donations
                .Include(d => d.Donor)
                .SingleOrDefaultAsync(d => d.Id == id);

            return donation;
        }

        public async Task<int> Add(Donation donation)
        {
            await _context.AddAsync(donation);
            await _context.SaveChangesAsync();

            return donation.Id;
        }   

        public async Task Update(Donation donor)
        {
            _context.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(d => d.Id == id);

            if (donation == null)
                return;

            _context.Donations.Remove(donation);
            await _context.SaveChangesAsync();
        }
    }
}
