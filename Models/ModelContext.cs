using Microsoft.EntityFrameworkCore;
namespace nmprojects.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(){
        }
        public DbSet<Student> Students{set; get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=.\;Database=student;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}