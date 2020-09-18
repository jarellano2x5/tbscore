using tbscore.Models;
using System.Threading.Tasks;

namespace tbscore.Interfaces
{
    public interface IBTDato : IGeneric<BTDato>
    {
        Task<int> CreateBin(BTDatoBin entity);
        Task<BTDatoBin> GetBinId(int id);
    }
}