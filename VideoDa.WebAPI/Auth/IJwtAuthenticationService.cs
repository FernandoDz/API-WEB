using VideoDa.EntidadesDeNegocio;

namespace VideoDa.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
