using EntityFrameWork;
using Models.Entity;
using Models.Repository;
using System;
using System.Threading.Tasks;

namespace Model.AMI.Repository.Provider
{

    public class RoleRepository : GenericRepository<Role>
    {
        private readonly AMIDbContext _context;

        public RoleRepository(AMIDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public new async Task Create(Role create)
        {
            if (create == null)
            {
                throw new ArgumentNullException();
            }

            create.Id = Guid.NewGuid();
            await base.Create(create);
        }
    }
}
