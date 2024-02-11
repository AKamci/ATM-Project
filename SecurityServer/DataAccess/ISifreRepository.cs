using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISifreRepository
    {

        MusteriSifre SifreKartKontrol (int kartno, string password);
        Task Kontrol();

        Task<MusteriSifre> KartTabloKontrol(int kartNo);


    }
}
