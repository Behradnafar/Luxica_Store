using Luxica_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Luxica_Store.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserRoles { get; set; }

        //int SaveChanges(bool acceptAllChangesOnSuccess);
        //int SaveChanges();
        //Task<int> SaveChangesAsyn(bool acceptAllChangesOnSuccess, CancellationToken cancelationToken = new CancellationToken());
        //Task<int> SaveChangesAsyn(CancellationToken cancelationToken = new CancellationToken());

    }
}
