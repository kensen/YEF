using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Infrastructure
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
