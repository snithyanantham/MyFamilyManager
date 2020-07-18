using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyManager.Mobile.Services
{
    public class IdentityService : IIdentityService
    {
        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyRegistration()
        {
            await Task.Delay(1337);
            return false;
        }
    }
}
