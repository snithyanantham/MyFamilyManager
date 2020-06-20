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

        public void SaveFamily(Family family)
        {
            _unitOfWork.FamilyRepository.Insert(family);
        }
    }
}
