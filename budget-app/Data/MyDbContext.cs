using Microsoft.EntityFrameworkCore;

namespace budget_app.Data
{
    public sealed class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        private DbSet<Record> Record => Set<Record>();

        public async Task<List<Record>> GetAllRecords() =>
            await Record.ToListAsync();

        public async Task<Record?> GetRecordById(Guid id)
        {
            var record = await Record
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return record;
        }
        
        public async Task<List<Record>> GetAllRecordsByUserId(Guid id)=> await Record
                .Where(p => p.Id == id).ToListAsync();
        
        public async Task CreateRecord(Record record)
        {
            await Record.AddAsync(record);
            await SaveChangesAsync();
        }

        public async Task DeleteRecord(Guid recordId)
        {
            var record = await Record.FirstOrDefaultAsync(p => p.Id == recordId);
            if (record == null)
            {
                Console.WriteLine("Error DeleteRecord");
                return;
            }
            
            Record.Remove(record);
            await SaveChangesAsync();
        }

        public async Task UpdateRecord(Record newRecord)
        {
            var record = await Record.FirstOrDefaultAsync(p => p.Id == newRecord.Id);
            if (record == null)
            {
                Console.WriteLine("Error UpdateRecord");
                return;
            }

            record.Category = newRecord.Category;
            record.Cost = newRecord.Cost;
            record.Description = newRecord.Description;
            record.Date = newRecord.Date;
            
            await SaveChangesAsync();
        }
    }
}
