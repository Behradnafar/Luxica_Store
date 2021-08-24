using Luxica_Store.Domain.Entities.Common;
using System.Collections.Generic;

namespace Luxica_Store.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
