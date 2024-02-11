using AtmUygulamasıDeneme.API.Models;
using AtmUygulamasıDeneme.Business.Abstract;
using AtmUygulamasıDeneme.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtmUygulamasıDeneme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class MusteriController : ControllerBase
    {


        private IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }
        

        
        [HttpGet]

        public async Task<IActionResult> Get()

        {
            var musteri = await _musteriService.GetAllMusteri();
            return Ok(musteri); // 200 + data
        }

         [HttpGet]

         [Route("[action]/{id}")]

         public async Task<IActionResult> GetMusteriById(int id)

        {
            var musteri = await _musteriService.GetMusteriById(id);
            if (musteri != null)
            {
                return Ok(musteri);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("[action]/{kartno}")]
        public async Task<IActionResult> GetMusteriByKartNo(int kartno)

        {
            var musteri = await _musteriService.GetMusteriByKartNo(kartno);
            if (musteri != null)
            {
                return Ok(musteri); //değiştirdim burayı ******



                //Burada bi tane musteri.KartNo gönderen action aç kartı onaylamak için
                //sadece girilen kartı doğrulasın yeterli başka bilgi döndürmeyecek ve
                //allowananoymous olacak böylece herkesin baştan erişim yetkisi olacak
                //aynı şekilde giriş postu içinde herkes  giriş yapmayı deneyecek fakat     
                //bakiye değişikliği için sadece girişi onaylannış kullanıcılar sistemde olacak.//
                //Yeni bir controller eklenerek kullanıcı doğruluğu orada test edilebilir ya da
                // aynı kontrol içerisinde kart ve giriş için gereken kısımlar onaysız gerisi onaylı hale getirilir::...
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("[action]")]
        
        public async Task<IActionResult> CreateMusteri([FromBody] Musteri musteri)
        {
            var createdMusteri = await _musteriService.CreateMusteri(musteri);


            return CreatedAtAction("Get", new { id = createdMusteri.Id }, createdMusteri);//201+data
        } 
        
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMusteriSifreTablo([FromBody] MusteriSifre musteriSifre)
        {
            var createdMusteri = await _musteriService.CreateMusteriSifreTablo(musteriSifre);

            return CreatedAtAction("Get", new { id = createdMusteri.Id }, createdMusteri);//201+data
        }



        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMusteri([FromBody] Musteri musteri)
        {
            if (await _musteriService.GetMusteriById(musteri.Id) != null)
            {
                return Ok(await _musteriService.UpdateMusteri(musteri));//200+data
            }
            return NotFound();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMusteriBakiye([FromBody] Musteri musteri)
        {
            if (await _musteriService.GetMusteriById(musteri.Id) != null)
            {
                return Ok(_musteriService.UpdateMusteriBakiye(musteri));//200+data
            }
            return NotFound();
        }


    }
}
