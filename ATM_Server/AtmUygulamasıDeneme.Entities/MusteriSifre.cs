using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmUygulamasıDeneme.Entities
{
    public class MusteriSifre
    {


        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int KartNo { get; set; }

        [StringLength(250)]
        [Required]
        public string Password { get; set; }

    }
}
