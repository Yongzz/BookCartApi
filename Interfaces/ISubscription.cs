using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Interfaces
{
    public interface ISubscription<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetSubscriptions();
        Task<TEntity> GetSubscription(int id);
        Task<bool> SubscribeOrUnsubscribe(int subScriptionId, int bookId, int userId);
        Task<bool> Issubscribe(int userId, int bookId);
    }
}
