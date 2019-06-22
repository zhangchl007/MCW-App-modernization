using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Apps.Insurance.Data
{
    public class ContosoInsuranceContext : DbContext, IContosoInsuranceContext
    {
        public DbSet<Dependent> Dependents { get; set; } 

        public DbSet<Person> People { get; set; }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<PolicyHolder> PolicyHolders { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var rows = await SaveChangesAsync();

            return rows;
        }

        private readonly string connectionString;

        public ContosoInsuranceContext(DbContextOptions options) : base(options)
        { }

        public ContosoInsuranceContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ContosoInsuranceContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }


        //public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        //{
        //    var sqlValue = param.SqlValue;
        //    var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
        //    if (nullableValue != null)
        //        return nullableValue.IsNull;
        //    return (sqlValue == null || sqlValue == System.DBNull.Value);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .HasMany(c => c.Dependents)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder
            //    .Entity<Dependent>()
            //    .HasOne(c => c.Person)
            //    .WithMany(c => c.Dependents)
            //    .HasForeignKey(c => c.PersonId)
            //    .OnDelete(DeleteBehavior.Cascade);

           
        }

        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Configurations.Add(new DependentConfiguration());
        //    modelBuilder.Configurations.Add(new PersonConfiguration());
        //    modelBuilder.Configurations.Add(new PolicyConfiguration());
        //    modelBuilder.Configurations.Add(new PolicyHolderConfiguration());
        //}

        //public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        //{
        //    modelBuilder.Configurations.Add(new DependentConfiguration(schema));
        //    modelBuilder.Configurations.Add(new PersonConfiguration(schema));
        //    modelBuilder.Configurations.Add(new PolicyConfiguration(schema));
        //    modelBuilder.Configurations.Add(new PolicyHolderConfiguration(schema));
        //    return modelBuilder;
        //}
    }
}
