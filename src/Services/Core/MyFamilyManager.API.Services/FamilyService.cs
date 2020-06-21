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
        private readonly IUnitOfWork _unitOfWork;
        public FamilyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FamilyDto GetFamily(Guid Id)
        {
            var family = _unitOfWork.FamilyRepository.GetById(Id);
            if (family != null)
            {
                return new FamilyDto
                {
                    Id = family.Id,
                    Name = family.Name,
                    Description = family.Description
                };
            }
            else
            {
                return null;
            }
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
