using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WebAPI.Application.Services;
using WebAPI.Core.Interface;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Interfaces
{
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository _repository;
        private ICoreRepository _coreRepository;
        public IMapper _mapper;
        public UserMasterService(IUserMasterRepository repository, ICoreRepository coreRepository, IMapper mapper)
        {
            _repository = repository;
            _coreRepository = coreRepository;
            _mapper = mapper;
        }

        List<VMUserMaster> IUserMasterService.GetUsers(PageModel pageModel)
        {
            var data = _repository.GetUsers(pageModel);
            return data;
        }

        int IUserMasterService.SaveUser(VMUserMaster vMUser, int UserID)
        {
            UserMaster user = _mapper.Map<UserMaster>(vMUser);
            int data = _repository.SaveUser(user, UserID);
            return data;
        }

        int IUserMasterService.DeleteUser(int id, int UserID)
        {
            int data = _repository.DeleteUser(id, UserID);
            return data;
        }

        public VMUserLoginRespose Authenticate(VMUserLogin userLogin, byte[] Key, byte[] IV)
        {
            userLogin.Password = Convert.ToBase64String(_coreRepository.EncryptString(userLogin.Password, Key, IV));
            UserMaster user = _repository.Authenticate(userLogin);
            var token = _coreRepository.TokenGenerator(user);
            VMUserLoginRespose loginRespose = new VMUserLoginRespose();
            loginRespose.Token = token;
            loginRespose.RoleID = user.Role;
            loginRespose.UserName = user.UserName;
            return loginRespose;
        }

        public VMUserMaster ProfileData(int UserID)
        {
            VMUserMaster data = _repository.ProfileData(UserID);
            return data;
        }

        public int UpdateProfile(VMUserMaster vMUser)
        {
            int data = _repository.UpdateProfile(vMUser);
            return data;
        }

        public int ResetPassword(string MailAddress, string newPassword, byte[] Key, byte[] IV)
        {
            string encryptedPass = Convert.ToBase64String(_coreRepository.EncryptString(newPassword, Key, IV));
            int data = _repository.ResetPassword(MailAddress, encryptedPass);
            return data;
        }

        public int GetOTP(string Host, int Port, string HostUserName, string HostPassword, string ToMailAddress)
        {
            var data = _repository.GetUser(ToMailAddress);
            if (data != null)
            {
                int data2 = _coreRepository.MailSender(Host, Port, HostUserName, HostPassword, data);
                if(data2 == 0)
                {
                    return -1;
                }
                return data2;
            }
            return 0;
        }

        public int CheckOTP(string MailAddress, int OTP)
        {
            var data = _repository.CheckOTP(MailAddress, OTP);
            return data;
        }

    }
}
