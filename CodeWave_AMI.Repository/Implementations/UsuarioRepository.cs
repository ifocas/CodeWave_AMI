using CodeWave_AMI.Data;
using CodeWave_AMI.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWave_AMI.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private _AmiDbContext _ctx;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioRepository(_AmiDbContext ctx, IHttpContextAccessor httpContextAccessor)
        {
            _ctx = ctx;
            _httpContextAccessor = httpContextAccessor;
        }

        public Usuario BuscarMailYPassword(string email, string password)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<string> ObtenerMails()
        {
            List<String> listaMails = new List<String>();

            foreach (var u in (from u in _ctx.Usuarios
                               select new { u.Email }).ToList())
            {
                listaMails.Add(u.Email);
            }
            return listaMails;
        }

        public void Registrar(Usuario usuario)
        {
            _ctx.Add(usuario);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }


    }
}
