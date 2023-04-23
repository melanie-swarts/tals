using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tals.Data.Models;

namespace Tals.Application.Services
{
    public interface ISsoUserService
    {
        IList<SsoUser> GetSsoUsers();
    }
}
