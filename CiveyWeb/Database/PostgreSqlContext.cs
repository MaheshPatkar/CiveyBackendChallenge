using CiveyWeb.Database.DbModels ;
using Microsoft.EntityFrameworkCore;

namespace CiveyWeb.Database
    {
    public class PostgreSqlContext : DbContext
        {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
            {
            }

        public DbSet<PollDtoModel> poll { get; set; }

        public DbSet<AnswersDtoModel> answer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);
            }

        public override int SaveChanges()
            {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
            }
        }
    }
