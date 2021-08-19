using Luxica_Store.Application.Interfaces.Contexts;
using Luxica_Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Luxica_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(x => new RolesDto
            { 
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };

        }
    }
}
