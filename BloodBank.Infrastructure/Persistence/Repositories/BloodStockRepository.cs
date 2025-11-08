using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using BloodBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankDbContext _context;

        public BloodStockRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<BloodStock>> GetAll()
        {
            var bloodStocks = await _context.BloodStock
                .ToListAsync();

            return bloodStocks;
        }

        public async Task<BloodStock?> GetById(int id)
        {
            var bloodStock = await _context.BloodStock
                .SingleOrDefaultAsync(d => d.Id == id);

            return bloodStock;
        }

        public async Task<int> Add(BloodStock bloodStock)
        {
            await _context.AddAsync(bloodStock);
            await _context.SaveChangesAsync();

            return bloodStock.Id;
        }

        public async Task Update(BloodStock bloodStock)
        {
            _context.Update(bloodStock);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bloodStock = await _context.BloodStock.SingleOrDefaultAsync(d => d.Id == id);

            if (bloodStock == null)
                return;

            _context.BloodStock.Remove(bloodStock);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByBloodType(BloodType bloodType)
        {
            return await _context.BloodStock
                .AnyAsync(b => b.BloodType == bloodType);
        }
    }
}
