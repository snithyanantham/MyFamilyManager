using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface IFamilyService
    {
        Family GetFamily(Guid Id);
        void SaveFamily(Family family);
    }
}
