using Model.AMI.Repository.Provider;
using Model.AMI.Service.Interface;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.AMI.Service.Provider
{
    public class AccountService : IAccountService ,IDisposable
    {
        private AccountRepository _AccountRepository;

        public AccountService(AccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        public  void Dispose()
        {
            _AccountRepository?.Dispose();
        }

        public async Task<List<Models.Entity.Account>> ReadAll()
        {
            var Data = await Task.Run(() => _AccountRepository.ReadAll());
            return Data.ToList();
        }

        public async Task<Account> ReadBy(Guid id)
        {
            var Data = await Task.Run(() =>
            _AccountRepository
            .ReadBy(x => x.Id == id));
            return Data;
        }

        public async Task<Account> Login(string username, string password)
        {
            try
            {
                Account Data = await Task.Run(() =>
                _AccountRepository
                .ReadBy(x => x.UserName == username.Trim() & x.Password == password.Trim()));
                return Data ?? null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Models.Entity.Account> Tip()
        {
            var Data = await Task.Run(() =>
            _AccountRepository
            .ReadAll()
            .GetAwaiter().GetResult()
            .OrderByDescending(x => x.UpdateDate).FirstOrDefault()
            );
            return Data;
        }

        public async Task<Guid> Create(Account create)
        {
            await _AccountRepository.Create(create);
            await _AccountRepository.SaveChanges();
            return create.Id;
        }

        public async Task<Guid> Update(Account updata)
        {
            try
            {
                await _AccountRepository.Update(updata);
                await _AccountRepository.SaveChanges();
                return updata.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public async Task<bool> Delete(Account delete)
        {
            try
            {
                await _AccountRepository.Delete(delete);
                await _AccountRepository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
} 
