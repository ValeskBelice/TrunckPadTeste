using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;
using TrunckPad.Domain.Interfaces.Services;


namespace TrunckPad.Domain.Services
{
    public class ServiceGeo : IServiceGeo
    {
        public GoogleGeoCodeResponse GetLocation(Endereco endereco)
        {
            StringBuilder address = new StringBuilder();
            address.AppendFormat("https://maps.googleapis.com/maps/api/geocode/json?address={0} {1} {2} {3}&key={4}", endereco.Numero,
                endereco.Logradouro, endereco.Cidade, endereco.Uf, "AIzaSyB6ybjbMibY_RLrC0_Hb9x82hQeesYNawM");
            var result = new System.Net.WebClient().DownloadString(address.ToString());
            return JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
        }
    }
}
