using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SifreRepository :ISifreRepository
    {
        public MusteriSifre SifreKartKontrol(int kartNo, string password)
        {

            using (var sifreDbContext = new SifreDbContext())
            {
                // var donenMusteri = musteriDbContext.Musteriler.SingleOrDefault(m => m.KartNo == kartNo && m.Password == Sifre);
                // string passwords = kartNo.ToString() + password.ToString();   

                //**********************************************************************

                // ** CL SS TRUE **

                // Create a new Loglar instance and set its properties
                var newLog = new Loglar
                {
                    Konum = "CLIENT",
                    HedefKonum = "SECURITY SERVER",
                    BasarıDurum = "OLUMLU",
                    Islem = "SIFRE KONTROL",
                    Tarih = DateTime.Now

                };

                // Add the newLog instance to the DbSet
                sifreDbContext.Loglar.Add(newLog);

                // Save changes to the database
                sifreDbContext.SaveChanges();



                var donen = sifreDbContext.TabloSifre.SingleOrDefault(m => m.Password == password && m.KartNo == kartNo);
                
                if (donen != null)
                {
                  // VERİ TABANINA MUSTERİNİN DOĞRULANDIĞINI YAZ


                    return donen;
                }
                else
                {
                    // VERİ TABANINA MÜŞTERİNİN ŞİFRESİNİ YANLIŞ GİRDİĞİNİ BELİRT 
                    return null;
                }

                
            }





            
        }



        public async Task Kontrol()
        {
            using (var ssContext = new SifreDbContext())
            {
                // Create a new Loglar instance and set its properties
                var newLog = new Loglar
                {
                    Konum = "SECURITY SERVER",
                    HedefKonum = "CLIENT",
                    BasarıDurum = "OLUMLU",
                    Islem = "KONTROLCEVABI",
                    Tarih = DateTime.Now

                };

                // Add the newLog instance to the DbSet
                ssContext.Loglar.Add(newLog);

                // Save changes to the database
                await ssContext.SaveChangesAsync();
            }
        }

        public async Task<MusteriSifre> KartTabloKontrol(int kartNo)
        {
            using (var sifreDbContext = new SifreDbContext())
            {
                MusteriSifre musteriSifre = new MusteriSifre();
                musteriSifre.KartNo = kartNo;

                return sifreDbContext.TabloSifre.SingleOrDefault(m => m.KartNo == kartNo);
            }
        }
    }
}
