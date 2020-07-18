using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyManager.Mobile.Services
{
    public interface IIdentityService
    {
        Task<bool> VerifyRegistration();
        Task Authenticate();
    }
}
