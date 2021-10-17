using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojisteniMVC.Models
{
    public class Pojisteny
    {
        [Key]
        public int PojistenyId { get; set; }
        [Required]
        [Display(Name ="Jméno")]
        [MaxLength(50)]
        public string Jmeno { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        [MaxLength(50)]
        public string Prijmeni { get; set; }
        public string Adresa { get; set; }
    }
}
