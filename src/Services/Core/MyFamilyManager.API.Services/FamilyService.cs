using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Services
{
    public class FamilyService : IFamilyService
    {
        private IUnitOfWork _unitOfWork;
        public FamilyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Family GetFamily(Guid Id)
        {
            return _unitOfWork.FamilyRepository.GetById(Id);
        }

        public void SaveFamily(FamilyDto family)
        {
            Family familyEntity = new Family
            {
                Name = family.Name,
                Description = family.Description
            };
            _unitOfWork.FamilyRepository.Insert(familyEntity);
            _unitOfWork.Commit();
        }
    }
}
