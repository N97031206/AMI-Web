
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.AMI.Service.Interface
{
    public interface IAccountService
    {
        Task<Guid> Create(Account create);
        Task<bool> Delete(Account delete);
        Task<Account> Login(string username, string password);
        Task<List<Account>> ReadAll();
        Task<Account> ReadBy(Guid id);
        Task<Account> Tip();
        Task<Guid> Update(Account updata);
        void Dispose();
    }
}