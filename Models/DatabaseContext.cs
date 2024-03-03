using Microsoft.EntityFrameworkCore;

namespace efcorePro.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }    
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) 
        {
            
        }   
        
        public virtual DbSet<RegisterModel> RegisterModels { get; set; }
        public virtual DbSet<LoginModel> LoginModel { get; set; }
        public virtual DbSet<EmployeeModel> EmployeeModels { get; set; }

        public virtual DbSet<CountryModel> CountryModels { get; set; }
    }
}
