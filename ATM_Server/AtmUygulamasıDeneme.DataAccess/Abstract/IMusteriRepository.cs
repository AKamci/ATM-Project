using AtmUygulamasıDeneme.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmUygulamasıDeneme.DataAccess.Abstract
{
    public interface IMusteriRepository
    {
        Task<List<Musteri>> GetAllMusteri();

        Task<Musteri> GetMusteriById(int id);

        Task<Musteri>GetMusteriByKartNo(int kartNo);

        Musteri SifreKartKontrol(string kontrol);

        Task<Musteri> GetMusteriByOnlyKartNo(int kartNo);
        Task<Musteri> GetMusteriSifreKart(int kartNo, int Sifre);

        
        Task<Musteri> CreateMusteri(Musteri musteri);

        Task<MusteriSifre> CreateMusteriSifreTablo(MusteriSifre musteriSifre);

        Task<Musteri> UpdateMusteri(Musteri musteri);

        Task<Musteri> UpdateMusteriBakiye(Musteri musteri);

        Task DeleteMusteri(int id);


    }
}
