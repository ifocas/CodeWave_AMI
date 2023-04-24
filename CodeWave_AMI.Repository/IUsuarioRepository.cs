using CodeWave_AMI.Data.Entities;

namespace CodeWave_AMI.Repository
{
    public interface IUsuarioRepository
    {
        public void Registrar(Usuario usuario);
        public List<String> ObtenerMails();
        public void SaveChanges();

        public Usuario BuscarMailYPassword(string email, string password);



    }
}