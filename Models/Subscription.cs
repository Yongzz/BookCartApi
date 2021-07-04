using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Models
{
    [Table(nameof(Subscription))]
    public class Subscription
    {
        public int Id { set; get; }
        [StringLength(150)]
        public string Description { set; get; }
        public int Months { set; get; }
        public float DiscountPercentage { get;  set; }
        public virtual ICollection<UserSubscriptionRelation> UserSubscriptionRelations { set; get; }

    }
    [Table(nameof(UserSubscriptionRelation))]
    public class UserSubscriptionRelation
    { 
        public int BookId { set; get; }
        public int SubscriptionId { set; get; }
        public int UserId { set; get; }
        public DateTime? ExpireDate { set; get; }
        public DateTime? SubscriptionDate { set; get; }
        public float Price { set; get; }
        public bool Active  { set; get; }



        [ForeignKey("BookId")]
        public virtual Book Book { set; get; }  
        [ForeignKey("UserId")]
        public virtual User User { set; get; }
        [ForeignKey("SubscriptionId")]
        public virtual Subscription Subscription { set; get; }
    
    }

}
