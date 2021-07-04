using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Models
{
    [Table(nameof(User))]
    public class User :  IdentityUser<int>
    {
        public override int Id { set; get; }
        [StringLength(50)]
        public override string UserName { set; get; }
        [StringLength(50)]
        public string FirstName { set; get; }
        [StringLength(50)]
        public string LastName { set; get; }
        [StringLength(150)]
        public string EmailAddress { set; get; }
        [NotMapped]
        public string Password { set; get; }
        public virtual ICollection<UserSubscriptionRelation> UserSubscriptionRelations { set; get; }
    }
}
