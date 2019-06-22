using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Apps.Insurance.Data
{
    public interface IContosoInsuranceContext : IDisposable
    {
        DbSet<Dependent> Dependents { get; set; }

        DbSet<Person> People { get; set; }

        DbSet<Policy> Policies { get; set; }

        DbSet<PolicyHolder> PolicyHolders { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
