using Posto.ApplicationCore.Enum;

namespace Posto.ApplicationCore.ViewModels
{
    public class UsuarioVM
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public string IdentityUser { get; set; }
        public EnumPerfil Perfil { get; set; }
        public int? Id_Endereco { get; set; }
    }

    public class UsuarioIdentityVM : UsuarioVM
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public string Password { get; set; }
        public string Endereco_Complemento { get; set; }
        public string LinkGoogleMaps { get; set; }
    }

    public class UsuarioAppVM
    {
        public string Token { get; set; }
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
    }
}