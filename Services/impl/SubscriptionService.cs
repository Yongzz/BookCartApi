using BookCartApi.Data;
using BookCartApi.Interfaces;
using BookCartApi.Models;
using BookCartApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscription<Subscription> _subscribe;
        public SubscriptionService(BookContext context)
        { _subscribe = new SubscriptionRepository(context); }

        public async Task<bool> SubscribeOrUnsubscribe(int subscriptionId, int bookId, int userId)
        {
            return await _subscribe.SubscribeOrUnsubscribe(subscriptionId, bookId, userId); ;
        }

        public async Task<Subscription> GetSubscription(int id)
        {
            return await _subscribe.GetSubscription(id);
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            return await _subscribe.GetSubscriptions();
        }

        public async Task<bool> Issubscribe(int userId, int bookId)
        {
            return await _subscribe.Issubscribe(userId, bookId);
        }
    }
}
