﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.Infrastructure;
using Elight.IService;
using Elight.IRepository;
using Elight.Entity.ResponseModels;

namespace Elight.Service
{
    public partial class UserService : BaseService<Sys_User, Guid>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override object Insert(Sys_User model)
        {
            //model.Id = Guid.NewGuid().ToString();
            model.DeleteMark = false;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            model.ModifyUser = model.CreateUser;
            model.ModifyTime = model.CreateTime;
            model.Avatar = "/content/framework/images/avatar.png";
            _userRepository.Insert(model);
            return model.Id;
        }

        public override int Update(Sys_User model)
        {
            model.ModifyUser = OperatorProvider.Instance.Current.Account;
            model.ModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "RealName", "NickName", "Gender", "Birthday", "MobilePhone",
                "Email", "Signature", "Address", "OrganizeId" , "ManagerId",
                "IsEnabled", "SortCode", "ModifyUser" , "ModifyTime"};
            return _userRepository.Update(model, updateColumns);
        }

        public Sys_User GetByUserName(string account)
        {
            return _userRepository.GetByAccount(account);
        }

        public Page<Sys_User> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return _userRepository.GetList(pageIndex, pageSize, keyWord);
        }

        public int UpdateBasicInfo(Sys_User model)
        {
            model.ModifyUser = OperatorProvider.Instance.Current.Account;
            model.ModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "RealName", "NickName", "Gender", "Birthday",  "MobilePhone",
                "Avatar", "Email", "Signature", "Address", "ModifyUser" , "ModifyTime"};
            return _userRepository.Update(model, updateColumns);
        }
    }
}
