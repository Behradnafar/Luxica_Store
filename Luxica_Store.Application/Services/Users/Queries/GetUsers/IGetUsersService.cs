using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luxica_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Exceute(ReuestGetUserDto request);
    }
}
