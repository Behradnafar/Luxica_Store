using Luxica_Store.Application.Interfaces.Contexts;
using Luxica_Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Luxica_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Exceute(ReuestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(x => x.FullName.Contains(request.SearchKey) || x.Email.Contains(request.SearchKey));
            }


            //Pagination
            int rowsCount = 0;
            var userList = users.ToPaged(request.Page, 20, out rowsCount).Select( p => new GetUsersDto
            { 
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = userList
            };
        }
    }
}
