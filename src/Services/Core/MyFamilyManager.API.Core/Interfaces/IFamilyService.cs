using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Models;
using System;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface IFamilyService
    {
        FamilyDto GetFamily(Guid Id);
        void SaveFamily(FamilyDto family);
    }
}
