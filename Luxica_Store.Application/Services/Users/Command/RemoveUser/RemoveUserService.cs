﻿using Luxica_Store.Application.Interfaces.Contexts;
using Luxica_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxica_Store.Application.Services.Users.Command.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(long UserId)
        {

            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}