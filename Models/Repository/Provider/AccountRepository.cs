
using EntityFrameWork;
using Models.Entity;
using Models.Repository;
using System;
using System.Threading.Tasks;


namespace Model.AMI.Repository.Provider
{

    public class AccountRepository: GenericRepository<Account>
    {
        private readonly AMIDbContext _context;

        public AccountRepository(AMIDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public new async Task Create(Account create)
        {
            if (create == null)
            {
                throw new ArgumentNullException();
            }

            create.Id = Guid.NewGuid();
            create.CreateDate = DateTime.Now;
            create.UpdateDate = DateTime.Now;

            await base.Create(create);
        }

        public new async Task  Update(Account update)
        {
            update.UpdateDate = DateTime.Now;
            await base.Update(update);
        }


    }
}
