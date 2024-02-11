using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System.Security.Claims;
using System.Text;
using Entities;
using SecServer2.Model;
using DataAccess;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SecServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class KullaniciDogruluk : ControllerBase
    {
       
        private readonly JwtAyarlari _jwtAyarlari;
        private readonly ISifreRepository _musteriService;

        public KullaniciDogruluk(ISifreRepository musteriService, IOptions<JwtAyarlari> jwtAyarlari)
        {
            _musteriService = musteriService;
            _jwtAyarlari = jwtAyarlari.Value;
        }

        [HttpPost("Giris")]
        [AllowAnonymous]
        public IActionResult Giris([FromBody] MusteriSifre musteriSifre)

        {
            
            
            var kullanici = KimlikDenetimiYap(musteriSifre);

            if (kullanici == null)
            {
                
                return NotFound("Hatalı Giriş");
            }
            else
            {

                var token = TokenOlustur(kullanici);
                return Ok(token);

            }




        }

        [HttpGet]
        [Route("[action]/{kartno}")]
        [AllowAnonymous]
        public async Task<IActionResult> KartTabloKontrol(int kartno)
        {
            var musteri = await _musteriService.KartTabloKontrol(kartno);

            if (musteri != null)
            {
                return Ok(musteri.KartNo); //değiştirdim burayı ******
            }
            else
            {
                return NotFound();
            }
        }




        [HttpGet]
        [Route("[action]")]
        public async Task Kontrol()
        {
            _musteriService.Kontrol();
        }


        private string TokenOlustur(MusteriSifre musteriSifre)
        {
            if (_jwtAyarlari.Key == null)
            {
                throw new Exception("JWT KEY NULL OLMAMALI");
            }
            else
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claimDizisi = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, musteriSifre.KartNo.ToString()), //Buraları düzeltmek gerekiyor.
                    new Claim(ClaimTypes.Name, musteriSifre.Id.ToString())
                };

                var token = new JwtSecurityToken(_jwtAyarlari.Issuer,

                    _jwtAyarlari.Audience,
                    claimDizisi,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
        }

        


        private MusteriSifre? KimlikDenetimiYap(MusteriSifre musteriSifre)
        {
            //string denemes =musteriSifre.KartNo.ToString() + musteriSifre.Password; 

            var musterikler = _musteriService.SifreKartKontrol(musteriSifre.KartNo, musteriSifre.Password);
            //var mussteri = _musteriService.GetMusteriSifreKart(musteris.KartNo, musteris.Password);

            // var musteriler = (Musteri)mussteri.Result;


            return musterikler;

        }





    }
}
