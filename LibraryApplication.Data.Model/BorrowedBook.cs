using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Data.Model
{
    public class BorrowedBook : BaseEntity
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }
        
        [Required]
        public DateTime BorrowedDate { get; set; }
        
        [Required]
        public DateTime BringDate { get; set; }

        public DateTime? BroughtDate { get; set; }
    }
}