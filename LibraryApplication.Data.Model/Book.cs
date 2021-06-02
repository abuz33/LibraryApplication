using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Data.Model
{
    public class Book:BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string BookName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string OrderNumber { get; set; }

        [Required]
        public int InStock { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
        
        [Required]
        public int WriterId { get; set; }
        
        public virtual Writer writer { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}
