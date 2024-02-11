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
    public class GirisKontrolleri : ControllerBase
    {

        private readonly JwtAyarlari _jwtAyarlari;
        private readonly IMusteriService _musteriService;

        public GirisKontrolleri(IMusteriService musteriService, IOptions<JwtAyarlari> jwtAyarlari)
        {
            _musteriService = musteriService;
            _jwtAyarlari = jwtAyarlari.Value;
        }


        [HttpGet]
        [Route("[action]/{kartno}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMusteriByOnlyKartNo(int kartno)

        {
            var musteri = await _musteriService.GetMusteriByOnlyKartNo(kartno);
            if (musteri != null)
            {
                return Ok(musteri.KartNo); //değiştirdim burayı ******
            }
            else
            {
                return NotFound();
            }
        }



        
        [HttpPost("Giris")]
        [AllowAnonymous]
        public IActionResult Giris([FromBody] Musteri musteri)
        
            {

            var kullanici = KimlikDenetimiYap(musteri);

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

        private string TokenOlustur(Musteri musteri)
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
                    new Claim(ClaimTypes.NameIdentifier, musteri.Name!),
                    new Claim(ClaimTypes.Name, musteri.Id.ToString())
                };

                var token = new JwtSecurityToken(_jwtAyarlari.Issuer,

                    _jwtAyarlari.Audience,
                    claimDizisi,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
        }

        private Musteri? KimlikDenetimiYap(Musteri musteris)
        {

            var musterikler = _musteriService.SifreKartKontrol(musteris.KartNo, musteris.Password);
            //var mussteri = _musteriService.GetMusteriSifreKart(musteris.KartNo, musteris.Password);

           // var musteriler = (Musteri)mussteri.Result;


            return musterikler;

        }







































        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> GirisAsync([FromBody] Musteri musteri)
        //{
        //    var MusteriKullanici = await KimlikDenetimiYap(musteri);

        //    if (MusteriKullanici == null)
        //    {

        //        return NotFound("Kullanıcı Bulunamadı");

        //    }
        //    else
        //    {
        //        var token = TokenOlustur((Musteri)MusteriKullanici);

        //        return Ok(token);
        //    }

        //}

        //private Musteri? TokenOlustur(IActionResult musteriKullanici)
        //{
        //    if (_jwtAyarlari.Key == null) throw new Exception("Jwt Key Null Olamaz");

        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));

        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //        var claimDizisi = new[]
        //        {
        //            new Claim(ClaimTypes)

        //        };

        //        var token = new JwtSecurityToken(_jwtAyarlari.Issuer,
        //            _jwtAyarlari.Audience,
        //            claimDizisi,
        //            expires: DateTime.UtcNow.AddMinutes(10),
        //            signingCredentials: credentials);

        //        var retdeger = new JwtSecurityTokenHandler().WriteToken(token);

        //    return retdeger;
        //}

        //private string TokenOlustur(Musteri musteri)
        //{
        //    if (_jwtAyarlari.Key == null) throw new Exception("Jwt Key Null Olamaz");
        //    {
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));

        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //        var claimDizisi = new[]
        //        {
        //            new Claim("KartNoClaim",musteri.KartNo.ToString()),
        //            new Claim("NameClaim", musteri.Name)
        //        };

        //        var token = new JwtSecurityToken(_jwtAyarlari.Issuer,
        //            _jwtAyarlari.Audience,
        //            claimDizisi,
        //            expires: DateTime.UtcNow.AddMinutes(10),
        //            signingCredentials: credentials);

        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
        //}



        //private async Task<IActionResult> KimlikDenetimiYap(Musteri musteri)
        //{
        //    var aktari = await _musteriService.GetMusteriSifreKart(musteri.KartNo, musteri.Password);
        //    return Ok(aktari);
        //  //  return Ok(await _musteriService.GetMusteriSifreKart(musteri.KartNo, musteri.Password));
        //}


        //[HttpGet]
        //[Route("[action]/{kartno}")]
        //public async Task<IActionResult> GetMusteriByOnlyKartNo(int kartno)

        //{
        //    var musteri = await _musteriService.GetMusteriByOnlyKartNo(kartno);
        //    if (musteri != null)
        //    {
        //        return Ok(musteri.KartNo); //değiştirdim burayı ******
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //private string TokenOlustur(Musteri musteri)
        //{
        //    if (_jwtAyarlari.Key == null) throw new Exception("Jwt Key Null Olamaz");
        //    {
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));

        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //        var claimDizisi = new[]
        //        {
        //            new Claim("KartNoClaim", musteri.KartNo.ToString()),
        //            new Claim("NameClaim", musteri.Name)
        //        };

        //        var token = new JwtSecurityToken(_jwtAyarlari.Issuer,
        //            _jwtAyarlari.Audience,
        //            claimDizisi,
        //            expires: DateTime.UtcNow.AddMinutes(10),
        //            signingCredentials: credentials);

        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
        //}







    }
}
