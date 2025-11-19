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

        public async Task<Donor?> GetById(int id)
        {
            var donor = await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.Donations)
                .SingleOrDefaultAsync(d => d.Id == id);

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
            var donor = await _context.Donors.SingleOrDefaultAsync(d => d.Id == id);

            if (donor == null)
                return;

            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<DateTime?> GetLastDonationDate(int donorId)
        {
            var donation = await _context.Donations
                .Where(d => d.IdDonor == donorId)
                .OrderByDescending(d => d.DonationDate)
                .FirstOrDefaultAsync();

            return donation?.DonationDate;

        }

        public async Task<bool> DonorEmailExists(string email, int? id)
        {
            return await _context.Donors
                .AnyAsync(e => e.Email == email && e.Id != (id ?? 0));
        }

        public async Task<List<Donation>> DonationsHistory(int idDonor)
        {
            var donations = await _context.Donations
                .Where(d => d.IdDonor == idDonor)
                .OrderByDescending(d => d.DonationDate)
                .ToListAsync();

            return donations;
        }
    }
}
