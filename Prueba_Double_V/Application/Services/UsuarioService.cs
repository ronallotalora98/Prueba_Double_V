using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prueba_Double_V.Application.DTOs;
using Prueba_Double_V.Application.Interfaces;
using Prueba_Double_V.Domain.Interfaces;
using Prueba_Double_V.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prueba_Double_V.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;
        private readonly string secrectKey;

        public UsuarioService(IUsuarioDomainService usuarioDomainService, IMapper mapper, IConfiguration config)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
            secrectKey = config.GetSection("settings").GetSection("secretkey").ToString();

        }
        public async Task<UsuarioDTO> CrearUsuario(LoginRequest usuarioRequest)
        {
            try
            {
                Usuario user = _mapper.Map<Usuario>(usuarioRequest);
                user.FechaCreacion = DateTime.Now;
                var usuario = await _usuarioDomainService.CrearUsuario(user);
                return _mapper.Map<UsuarioDTO>(usuario);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async  Task<LoginResponse> GetLogin(LoginRequest usuario)
        {
            try
            {
                var user = await _usuarioDomainService.GetUsuario(_mapper.Map<Usuario>(usuario));
                if (user != null)
                {
                    return GenerateToken(user);
                }

                return new LoginResponse { IsOk = false, Token = null, TimeToExpire = 0};
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private LoginResponse GenerateToken(Usuario usuario)
        {
            var keyBites = Encoding.ASCII.GetBytes(secrectKey);
            DateTime timeToExpiere = DateTime.UtcNow.AddMinutes(5);
            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.User));
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = timeToExpiere,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBites), SecurityAlgorithms.HmacSha256Signature),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);


            return new LoginResponse { IsOk = true, Token = token, TimeToExpire = 5, Id = usuario.Id, UserName = usuario.User };






        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, username),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "yourdomain.com",
        //        audience: "yourdomain.com",
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
