using AtmUygulamasıDeneme.Business.Abstract;
using AtmUygulamasıDeneme.DataAccess.Abstract;
using AtmUygulamasıDeneme.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AtmUygulamasıDeneme.Business.Concrete
{
    public class MusteriManager : IMusteriService
    {


        private IMusteriRepository _musteriRepository;

        public MusteriManager(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }

        public async Task<Musteri> CreateMusteri(Musteri musteri)
        {
            return await _musteriRepository.CreateMusteri(musteri);
        }
        public async Task<MusteriSifre> CreateMusteriSifreTablo(MusteriSifre musteriSifre)
        {
            return await _musteriRepository.CreateMusteriSifreTablo(musteriSifre);
        }

        public async Task DeleteMusteri(int id)
        {
           await _musteriRepository.DeleteMusteri(id);
        }

        public async Task<List<Musteri>> GetAllMusteri()
        {
            return await _musteriRepository.GetAllMusteri();
        }

        public async Task<Musteri> GetMusteriById(int id)
        {
            return await _musteriRepository.GetMusteriById(id);
        }

        public async Task<Musteri> GetMusteriByKartNo(int kartNo)
        {
            return await _musteriRepository.GetMusteriByKartNo(kartNo);
        }
        
        public async Task<Musteri> GetMusteriByOnlyKartNo(int kartNo)
        {

            return await _musteriRepository.GetMusteriByOnlyKartNo(kartNo);
        }
        
        public async Task<Musteri> GetMusteriSifreKart(int kartNo, int Sifre)
        {

            return await _musteriRepository.GetMusteriSifreKart(kartNo,Sifre);
        }

        public Musteri SifreKartKontrol(int kartNo, int Sifre)
        {
            
            string birleşim =
                kartNo.ToString() + Sifre.ToString();
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(birleşim));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                 builder.ToString();
                return _musteriRepository.SifreKartKontrol(builder.ToString());

            }


            

            
        }

        public async Task<Musteri> UpdateMusteri(Musteri musteri)
        {
            return await _musteriRepository.UpdateMusteri(musteri);
        }

        public async Task<Musteri> UpdateMusteriBakiye(Musteri musteri)
        {
            return await _musteriRepository.UpdateMusteriBakiye(musteri);
        }
    }
}
