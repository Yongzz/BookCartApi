using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Models
{
    [Table(nameof(Book))]
    public class Book
    {
        public int Id { set; get; }
        [StringLength(150)]
        public string Name { set; get; }
        [StringLength(80)]
        public string Category { set; get; }
        [StringLength(20)]
        public string ISBNo { set; get; }
        [Column(TypeName = "money")]
        public float PurchasePrice {set;get;}

    }
}
