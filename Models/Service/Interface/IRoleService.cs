using System;
using System.Threading.Tasks;

namespace Model.AMI.Service.Interface
{
    public interface IRoleService
    {
        Task<int> ReadID(Guid ID);
        Task<Guid> ReadRold(int value);
        void Dispose();
    }
}