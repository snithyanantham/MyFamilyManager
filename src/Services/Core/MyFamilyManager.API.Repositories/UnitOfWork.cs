using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFamilyManagerDbContext _myFamilyManagerDbContext;
        private IBaseRepository<FamilyMember> _familyMemberRepository;
        private IBaseRepository<Family> _familyRepository;
        private IBaseRepository<FamilyMemberType> _familyMemberTypeRepository;
        private IBaseRepository<Category> _categoryRepository;
        private IBaseRepository<SubCategory> _subCategoryRepository;
        private IBaseRepository<Transaction> _transactionRepository;

        public IBaseRepository<FamilyMember> FamilyMemberRepository
        {
            get { return _familyMemberRepository = _familyMemberRepository ?? new BaseRepository<FamilyMember>(_myFamilyManagerDbContext); }
        }

        public IBaseRepository<Family> FamilyRepository
        {
            get { return _familyRepository = _familyRepository ?? new FamilyRepository(_myFamilyManagerDbContext); }
        }

        public IBaseRepository<FamilyMemberType> FamilyMemberTypeRepository
        {
            get { return _familyMemberTypeRepository = _familyMemberTypeRepository ?? new BaseRepository<FamilyMemberType>(_myFamilyManagerDbContext); }
        }

        public IBaseRepository<Category> CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new BaseRepository<Category>(_myFamilyManagerDbContext); }
        }

        public IBaseRepository<SubCategory> SubCategoryRepository
        {
            get { return _subCategoryRepository = _subCategoryRepository ?? new BaseRepository<SubCategory>(_myFamilyManagerDbContext); }
        }

        public IBaseRepository<Transaction> TransactionRepository
        {
            get { return _transactionRepository = _transactionRepository ?? new BaseRepository<Transaction>(_myFamilyManagerDbContext); }
        }

        public void Commit()
        {
            _myFamilyManagerDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _myFamilyManagerDbContext.Dispose();
        }
    }
}
