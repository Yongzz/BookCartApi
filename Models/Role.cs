using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Models
{
    [Table(nameof(Role))]
    public class Role : IdentityRole<int>
    {
        [Key]
        public override int Id { get; set; }
        [StringLength(256)]
        public override string Name { get; set; }
        [StringLength(256)]
        public override string NormalizedName { get; set; }
        public override string ConcurrencyStamp { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }

}
