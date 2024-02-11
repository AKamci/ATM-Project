using System.ComponentModel.DataAnnotations;

namespace SwitchDenemeleri1
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
