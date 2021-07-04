using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Interfaces
{
    public interface IUser<TEntity> where TEntity : class
    {
    }
}
