using CodeWave_AMI.Data.Entities;
using CodeWave_AMI.Repository;
using CodeWave_AMI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWave_AMI.Service.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public bool CompararMails(string email)
        {
            if (_usuarioRepo.ObtenerMails().Contains(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Registrar(UsuarioViewModel usuariovm)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = usuariovm.Nombre;
            usuario.Email = usuariovm.Email;
            usuario.Password = usuariovm.Password;
            _usuarioRepo.Registrar(usuario);
            _usuarioRepo.SaveChanges();
        }



        public Usuario VerificarLogin(string email, string password)
        {
            return _usuarioRepo.BuscarMailYPassword(email, password);
        }
    }
}
