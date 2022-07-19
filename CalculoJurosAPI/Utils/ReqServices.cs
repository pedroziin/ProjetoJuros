using CalculoJurosAPI.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoJurosAPI.Utils
{
    public class ReqServices : IReqServices
    {
        public async Task<decimal> GetTaxaJuros(string url)
        {
            HttpClient req = new HttpClient();
            var content = await req.GetAsync(url);
            var taxaJuros = await content.Content.ReadAsStringAsync();

            return Convert.ToDecimal(taxaJuros);
        }
    }
}
