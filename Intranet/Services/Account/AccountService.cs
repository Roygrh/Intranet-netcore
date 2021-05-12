using AutoMapper;
using Intranet.Services.Ldap;
using Intranet.Services.Unit;
using Intranet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Account
{
    public class AccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public bool IsSignedIn()
        {
            return true;
        }

        public User GetUser(string dni)
        {
            User user = this._mapper.Map<User>(this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI.Trim().Equals(dni)).FirstOrDefault());
            
            if (user != null)
            {
                user.UserTypeName = this._unitOfWork.UserTypes.GetById(user.UserType).USER_TYPE_NAME;
            }

            return user;
        }
    }
}
