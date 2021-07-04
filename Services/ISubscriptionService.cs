using BookCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Services
{
    public interface ISubscriptionService
    {
        public Task<IEnumerable<Subscription>> GetSubscriptions();
        public Task<Subscription> GetSubscription(int id);
        public Task<bool> SubscribeOrUnsubscribe(int subscriptionId, int bookId, int userId);
        Task<bool> Issubscribe(int userId, int bookId);
    }
}
