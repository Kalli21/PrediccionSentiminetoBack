using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrediccionSentiminetoBack.Models;
using PrediccionSentiminetoBack.Models.DTO;
using PrediccionSentiminetoBack.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PrediccionSentiminetoBack.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PrediccionSentiminetoBackContext _db;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;
        public UsuarioRepository(PrediccionSentiminetoBackContext db, IConfiguration configuration, IMapper mapper)
        {
            _db = db;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<bool> DeleteUser(string username)
        {
            try
            {
                Usuario User = await _db.Usuario.Where(i => i.UserName == username).FirstOrDefaultAsync();
                if (User == null)
                    return false;
                _db.Usuario.Remove(User);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UsuarioDTO> GetUserById(string username)
        {
            Usuario user = await _db.Usuario.Where(i => i.UserName == username).FirstOrDefaultAsync();
            return _mapper.Map<UsuarioDTO>(user);
        }

        public async Task<ICollection<UsuarioDTO>> GetUsers()
        {
            ICollection<Usuario> users = await _db.Usuario.ToListAsync();
            return _mapper.Map<ICollection<UsuarioDTO>>(users);
        }

        public async Task<UsuarioDTO> Login(UsuarioDTO usuarioDTO)
        {
            Usuario user = await _db.Usuario.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(usuarioDTO.UserName.ToLower()));

            if (user == null)
            {
                usuarioDTO.Token = "nouser";
                return usuarioDTO;
            }
            else
            {
                if (!VerificarPasswordHash(usuarioDTO.Password, user.PasswordHash, user.PasswordSalt))
                {
                    usuarioDTO.Token = "wrongpassword";
                    return usuarioDTO;
                }
                else
                {

                    usuarioDTO = _mapper.Map<Usuario, UsuarioDTO>(user);
                    usuarioDTO.Token = CrearToken(user);
                    return usuarioDTO;
                }
            }
        }

        public async Task<UsuarioDTO> Register(UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario user = _mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);
                if (await UserExiste(user.UserName))
                {
                    usuarioDTO.Token = "existe";
                    return usuarioDTO;
                }

                CrearPasswordHash(usuarioDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.activo = true;

                await _db.Usuario.AddAsync(user);
                await _db.SaveChangesAsync();
                usuarioDTO = _mapper.Map<Usuario, UsuarioDTO>(user);
                usuarioDTO.Token = CrearToken(user);

                return usuarioDTO;
            }
            catch (Exception)
            {
                usuarioDTO.Token = "error";
                return usuarioDTO;
            }
        }

        public async Task<UsuarioDTO> UpdateUser(UsuarioDTO usuarioDTO)
        {
            Usuario user = _mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);
            Usuario auxU = await _db.Usuario.Where(i => i.UserName == usuarioDTO.UserName).FirstOrDefaultAsync();
            user.Id = auxU.Id;
            _db.Usuario.Update(user);
            await _db.SaveChangesAsync();
            return _mapper.Map<Usuario, UsuarioDTO>(user);
        }

        public async Task<bool> UserExiste(string username)
        {
            if (await _db.Usuario.AnyAsync(x => x.UserName.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        //Funciones Extra
        public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        private string CrearToken(Usuario user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration
                .GetSection("AppSetting:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
