using Tals.Data.Models;

namespace Tals.Application.Services
{
 public abstract class BaseService
    {
        private TalsContext? _talsContext;

        protected TalsContext TalsContext
        {
            get
            {
                if (_talsContext != null)
                {
                    return _talsContext;
                }

                return _talsContext = new TalsContext();
            }
        }
    }
}
