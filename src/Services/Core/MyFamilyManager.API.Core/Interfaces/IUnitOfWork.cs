using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<FamilyMember> FamilyMemberRepository { get; }
        IBaseRepository<Family> FamilyRepository { get; }
        IBaseRepository<FamilyMemberType> FamilyMemberTypeRepository { get; }
        IBaseRepository<Category> CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IBaseRepository<Transaction> TransactionRepository { get; }
        void Commit();
        void Rollback();
    }
}
