﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetail(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
