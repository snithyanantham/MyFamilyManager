using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        T Save(T entity);
    }
}
