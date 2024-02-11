using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Loglar
    {
        [Key]
        public int IslemSırası { get; set; }
        [StringLength(50)]
        public string Konum { get; set; }
        [StringLength(50)]
        public string HedefKonum { get; set; }
        [StringLength(50)]
        public string Islem { get; set; }
        [StringLength(50)]
        public string BasarıDurum { get; set; }

        public DateTime Tarih { get; set; }




    }
}
