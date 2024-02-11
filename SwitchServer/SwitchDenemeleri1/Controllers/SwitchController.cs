using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace SwitchDenemeleri1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {

        //[HttpGet]
        //[Route("[action]/{kartno}")]
        //public string? KartYonlendirme(int kartno)
        //{
        //    string kart = kartno.ToString();
        //    bool a = true;

        //    if (a == kart.EndsWith("00"))
        //    {
        //        return "https://localhost:44321/";
        //    }
        //    else if (a == kart.EndsWith("11"))
        //    {
        //        return "https://localhost:44333/";
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}




        [HttpGet]
        [Route("[action]/{kartno}")]
        public async Task<IActionResult> KartYonlendirme(int kartno)
        {


            // Buradan client tarafından mesaj geldiği onaylanmalı

            //Client tarafından gelen mesaj buraya ulaştır  **CL SW TRUE**
            using (var swContext = new SwDbContext())
            {
                // Create a new Loglar instance and set its properties
                var newLog = new Loglar
                {
                    Konum = "CLIENT",
                    HedefKonum = "SWITCH SERVER",
                    BasarıDurum = "OLUMLU",
                    Islem = "YONBILGI",
                    Tarih = DateTime.Now

                };

                // Add the newLog instance to the DbSet
                swContext.Loglar.Add(newLog);

                // Save changes to the database
               await swContext.SaveChangesAsync();
            }




            string kart = kartno.ToString();
            bool a = true;

            if (a == kart.EndsWith("00"))
            {
                // xx00 NUMARALI KARTI YÖNLENDİRDİM

                return Ok("https://localhost:44321/");   
            }
            else if (a == kart.EndsWith("11"))
            {
                return Ok("https://localhost:44333/");
            }
            else
            {
                return NotFound();  
            }















        }

        
        
        
        [HttpGet]
        [Route("[action]/{durumbilgisi}")]
        public async Task YonlendirmeBasari(int durumbilgisi)
        {
            if (durumbilgisi == 1)
            {
                using (var swContext = new SwDbContext())
                {
                    // Create a new Loglar instance and set its properties
                    var newLog = new Loglar
                    {
                        Konum = "SWITCH SERVER",
                        HedefKonum = "CLIENT",
                        BasarıDurum = "OLUMLU",
                        Islem = "YONLENDIRME",
                        Tarih = DateTime.Now

                    };

                    // Add the newLog instance to the DbSet
                    swContext.Loglar.Add(newLog);

                    // Save changes to the database
                    await swContext.SaveChangesAsync();
                }
            }
            else
            {
                using (var swContext = new SwDbContext())
                {
                    // Create a new Loglar instance and set its properties
                    var newLog = new Loglar
                    {
                        Konum = "SWITCH SERVER",
                        HedefKonum = "CLIENT",
                        BasarıDurum = "OLUMSUZ",
                        Islem = "YONLENDIRME",
                        Tarih = DateTime.Now

                    };

                    // Add the newLog instance to the DbSet
                    swContext.Loglar.Add(newLog);

                    // Save changes to the database
                    await swContext.SaveChangesAsync();
                }
            }

           


        }






    }
}
