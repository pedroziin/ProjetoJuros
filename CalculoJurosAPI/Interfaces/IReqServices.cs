using System.Threading.Tasks;

namespace CalculoJurosAPI.Interfaces
{
    public interface IReqServices
    {
        Task<decimal> GetTaxaJuros(string url);
    }
}
