using System.Threading.Tasks;
using tbscore.Models;

namespace tbscore.Interfaces
{
    public interface ITGUsuario : IGeneric<TGUsuario>
    {
        Task<TGUsuario> Login(string usu, string pwd);
    }
}