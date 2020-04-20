using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Repositories
{
    public class FamilyRepository:BaseRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(MyFamilyManagerContext context) : base(context)
        {

        }
    }
}
