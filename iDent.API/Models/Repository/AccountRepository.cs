﻿using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.ModelLibrary.Utility;

namespace iDent.API.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Result<Account>> AddAdminAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> AddAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAdminAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Pageable<Account>>> GetAllAdminPagedAsync(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GetResetPasswordCodeAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> LoginAsync(LoginRequest login)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> ResendOtpAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}