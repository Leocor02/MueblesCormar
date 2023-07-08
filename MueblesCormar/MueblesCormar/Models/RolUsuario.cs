using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MueblesCormar.Models
{
    public class RolUsuario
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public RolUsuario()
        {
            //Usuarios = new HashSet<Usuario>();
        }

        public int IdrolUsuario { get; set; }
        public string Rol { get; set; } = null!;

        //public virtual ICollection<Usuario> Usuarios { get; set; }

        //funciones para el modelo
        //en este caso será una función que llama al controlador que carga todos los roles
        //para luego mostrarlos en un piccker(combobox)
        public async Task<List<RolUsuario>> GetRolesUsurios()
        {
            try
            {
                string RouteSufix = string.Format("RolUsuarios");
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de la info en un json
                    var list = JsonConvert.DeserializeObject<List<RolUsuario>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
    }
}
