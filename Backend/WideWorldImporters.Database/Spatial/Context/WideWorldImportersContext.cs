// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using WideWorldImporters.Database.Models;

namespace WideWorldImporters.Database
{
    public partial class WideWorldImportersContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().Ignore(x => x.EdmLocation);
            modelBuilder.Entity<Country>().Ignore(x => x.EdmBorder);
            modelBuilder.Entity<Customer>().Ignore(x => x.EdmDeliveryLocation);
            modelBuilder.Entity<Supplier>().Ignore(x => x.EdmDeliveryLocation);
            modelBuilder.Entity<StateProvince>().Ignore(x => x.EdmBorder);
            modelBuilder.Entity<SystemParameter>().Ignore(x => x.EdmDeliveryLocation);
        }
    }
}
