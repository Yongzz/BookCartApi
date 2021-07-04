using BookCartApi.Data;
using BookCartApi.Interfaces;
using BookCartApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Repository
{
    public class SubscriptionRepository : ISubscription<Subscription>
    {
        private readonly BookContext _context;
        public SubscriptionRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Subscription> GetSubscription(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<bool> Issubscribe(int userId, int bookId)
        {
           return  !await _context.UserSubscriptionRelations.Where(sub=> sub.UserId == userId && sub.BookId == bookId && sub.Active == true).AnyAsync();
        }

        public async Task<bool> SubscribeOrUnsubscribe(int subScriptionId, int bookId, int userId)
        {
            var subscr = _context.Subscriptions.Find(subScriptionId);
            var entity = new UserSubscriptionRelation { Active = true, BookId = bookId, SubscriptionId = subScriptionId, UserId = userId, SubscriptionDate = DateTime.Now, ExpireDate = DateTime.Now.AddMonths(subscr.Months) };
            var dbSub = await _context.UserSubscriptionRelations.FindAsync(bookId, subScriptionId, userId);
            if (dbSub == null)
                _context.UserSubscriptionRelations.Add(entity);
            else
            {
                dbSub.Active = !dbSub.Active;

                if (dbSub.Active)
                {
                    dbSub.ExpireDate = DateTime.Now.AddMonths(subscr.Months);
                    dbSub.SubscriptionDate = DateTime.Now;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
