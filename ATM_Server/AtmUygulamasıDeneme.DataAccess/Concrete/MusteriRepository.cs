using AtmUygulamasıDeneme.DataAccess.Abstract;
using AtmUygulamasıDeneme.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmUygulamasıDeneme.DataAccess.Concrete
{
    public class MusteriRepository : IMusteriRepository
    {
       
        
        public async Task<Musteri> CreateMusteri(Musteri musteri)
        {
            using (var musteriDbContext = new MusteriDbContext())
            {
                musteriDbContext.Musteriler.Add(musteri);
                await musteriDbContext.SaveChangesAsync();
                return musteri;
            }
        }



        public async Task<MusteriSifre> CreateMusteriSifreTablo(MusteriSifre musteriSifre)
        {
            
            using (var musteriDbContext = new MusteriDbContext())
            {      
                
                musteriDbContext.TabloSifre.Add(musteriSifre);

                await musteriDbContext.SaveChangesAsync();

                return musteriSifre;
            }
        }










        public async Task DeleteMusteri(int id)
        {
            using (var musteriDbContext = new MusteriDbContext())
            {
                var deletedHotel = await GetMusteriById(id);
                musteriDbContext.Musteriler.Remove(deletedHotel);
                await musteriDbContext.SaveChangesAsync();
            }


        }

        public async Task<List<Musteri>> GetAllMusteri()
        {
            using(var musteriDbContext = new MusteriDbContext())
            {
                return await musteriDbContext.Musteriler.ToListAsync();
            }
        }

        public async Task<Musteri> GetMusteriById(int id)
        {
            using(var musteriDbContext = new MusteriDbContext())
            {
                return await musteriDbContext.Musteriler.FindAsync(id);
            }
        }

        public async Task<Musteri> GetMusteriByKartNo(int kartNo)
        {
            using (var musteriDbContext = new MusteriDbContext())
            {
               Musteri musteri  = new Musteri();
               musteri.KartNo = kartNo;

                //  int sifre = musteri.Password; sistem şifreyi aktarmalı

               //var Deger2 = await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo);

               // Deger2.Password = musteri.Password;

                        
                return await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo);
             



                //return await musteriDbContext.Musteriler.FindAsync(kartNo);
            }

        }

        //----------------------------
        public async Task<Musteri> GetMusteriByOnlyKartNo(int kartNo)
        {
            using (var musteriDbContext = new MusteriDbContext())
            {
                Musteri musteri = new Musteri();
                musteri.KartNo = kartNo;


                return await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo);

                //**********************************************************************
                // ** CL MS TRUE**


            }

        }

        //-----------------------------------------------------------------
        public async Task<Musteri> GetMusteriSifreKart(int kartNo, int sifrePin)
        {
            using (var musteriDbContext = new MusteriDbContext())
            {
                Musteri musteri = new Musteri();

                var DonenMusteri = await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo && m.Password == sifrePin);
               
                return DonenMusteri!;
               // return await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo && m.Password == sifrePin);
                //return await musteriDbContext.Musteriler.SingleOrDefaultAsync(m => m.KartNo == kartNo && m.Password == sifrePin);

            }

        }

        public Musteri SifreKartKontrol(string sifre)
        {

            using (var musteriDbContext = new MusteriDbContext())
            {
               // var donenMusteri = musteriDbContext.Musteriler.SingleOrDefault(m => m.KartNo == kartNo && m.Password == Sifre);

                var donen = musteriDbContext.TabloSifre.SingleOrDefault(m => m.Password == sifre);
                if (donen != null)
                {
                    var DonenMusteri = donen.KartNo;
                    var donenMusteri = musteriDbContext.MusteriDeger.SingleOrDefault(n => n.KartNo == DonenMusteri);
                    return donenMusteri;
                }
                

               


                return null;
            }
            

           
        }







        //------------------------------------------------------------------------


        public async Task<Musteri> UpdateMusteri(Musteri musteri)
        {
            using (var msContext = new MusteriDbContext())
            {
                // Create a new Loglar instance and set its properties
                var newLog = new Loglar
                {
                    Konum = "CLIENT",
                    HedefKonum = "MAIN SERVER",
                    BasarıDurum = "OLUMLU",
                    Islem = "BAKIYE DEGISIM ISTEGI",
                    Tarih = DateTime.Now

                };

                // Add the newLog instance to the DbSet
                msContext.Loglar.Add(newLog);

                // Save changes to the database
                await msContext.SaveChangesAsync();
            }


            using (var musteriDbContext = new MusteriDbContext())
            {
                musteriDbContext.Musteriler.Update(musteri);
                await musteriDbContext.SaveChangesAsync();
                return musteri;
            }
        }

        public async Task<Musteri> UpdateMusteriBakiye(Musteri musteri)
        {

            using (var musteriDbContext = new MusteriDbContext())
            {
                musteriDbContext.Musteriler.Update(musteri);
                await musteriDbContext.SaveChangesAsync();
                return musteri;
            }
        }
    }
}
