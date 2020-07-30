using tbscore.Models;

namespace tbscore.Interfaces
{
    public interface ITGUsuario : IGeneric<TGUsuario>
    {
        TGUsuario Login(string usu, string pwd);
    }
}