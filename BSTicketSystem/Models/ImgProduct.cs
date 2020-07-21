using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BSTicketSystem.Models
{
    [Table("ImgProduct")]
    public class ImgProduct
    {
        [Key]
        [Column(Order = 0)]
        public int Product_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Img_Id { get; set; }

        public Product Product { get; set; }
        public Img Img { get; set; }

    }
}