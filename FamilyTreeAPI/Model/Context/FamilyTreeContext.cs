using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Model.Context
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FamilyTree> FamilyTree { get; set; }
    }
}
