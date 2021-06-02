using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Data.Model
{
    public class Member:BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string MemberName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string MemberLastname { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)]
        public string IdentityNumber { get; set; }
        
        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistirationDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Mail { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(32), MinLength(32)]
        public string Password { get; set; }

        [Required]
        public int Punishment { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(1), MinLength(1)]
        public string Authorization { get; set; }

        public virtual List<BorrowedBook> BorrowedBooks { get; set; }
    }
}
