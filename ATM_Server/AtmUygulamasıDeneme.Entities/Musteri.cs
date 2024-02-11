using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmUygulamasıDeneme.Entities
{
    public class Musteri
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [StringLength(50)]
        [Required]
        public string Name { get; set; }


        [Required]
        public int Password { get; set; }
        
        
        [Required]
        public int KartNo { get; set; }
        
        
        [Required]

        public decimal Bakiye { get; set; }







    }
}
