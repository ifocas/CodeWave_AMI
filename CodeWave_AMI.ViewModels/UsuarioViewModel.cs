using System.ComponentModel.DataAnnotations;

namespace CodeWave_AMI.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre excede el límite de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de Email válida")]
        [MaxLength(50, ErrorMessage = "El email excede el límite de 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Ingrese una contraseña válida")]
        [MaxLength(50, ErrorMessage = "La contraseña excede el límite de 30 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Ingrese una contraseña válida")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [MaxLength(50, ErrorMessage = "La contraseña excede el límite de 30 caracteres")]
        public string RepitePassword { get; set; }


    }
}