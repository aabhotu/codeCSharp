using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public IOwnerRepository Owner
        {
            get
            {
                if(_owner != null)
                {
                    return _owner;
                }
                    return new OwnerRepository(_repoContext);
            }
        }
        public IAccountRepository Account
        {
            get
            {
                if(_account != null)
                {
                    return _account;
                }
                return new AccountRepository(_repoContext);
            }
            set { _account = value; }
        }
        public RepositoryWrapper (RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
