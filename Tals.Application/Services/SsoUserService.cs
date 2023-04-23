using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tals.Data.Models;

namespace Tals.Application.Services
{
    public class SsoUserService: BaseService, ISsoUserService
    {
        public IList<SsoUser> GetSsoUsers()
        {
            return TalsContext.SsoUsers.ToList();
        }
    }
}
