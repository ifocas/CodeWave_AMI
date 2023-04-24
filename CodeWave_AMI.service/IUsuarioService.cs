using CodeWave_AMI.Data.Entities;
using CodeWave_AMI.ViewModels;

namespace CodeWave_AMI.Service
{
    public interface IUsuarioService
    {
        public void Registrar(UsuarioViewModel usuariovm);
        public bool CompararMails(string email);
        public Usuario VerificarLogin(string email, string password);
    }
}