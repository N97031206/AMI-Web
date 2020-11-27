using Model.AMI.Repository.Provider;
using Model.AMI.Service.Interface;
using System;
using System.Threading.Tasks;


namespace Model.AMI.Service.Provider
{
    public class RoleService : IRoleService ,IDisposable
    {
        private RoleRepository _RoleRepository;

        public RoleService(RoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public async Task<int> ReadID(Guid ID)
        {
            var Data = await Task.Run(() =>
            _RoleRepository.ReadBy(x => x.Id == ID));
            return (int)Data.RoleType;
        }

        public  void Dispose()
        {
            _RoleRepository?.Dispose();
        }

        public async Task<Guid> ReadRold(int value)
        {
            var Data = await Task.Run(() =>
            _RoleRepository.ReadBy(x => (int)x.RoleType == value));
            return Data.Id;
        }
    }
} 
