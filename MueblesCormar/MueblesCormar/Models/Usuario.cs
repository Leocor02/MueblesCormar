using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.Models
{
    public class Usuario
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public Usuario()
        {
            //Bitacoras = new HashSet<Bitacora>();
            //Registros = new HashSet<Registro>();
        }

        public int Idusuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int IdrolUsuario { get; set; }

        public virtual RolUsuario IdrolUsuarioNavigation { get; set; } = null!;

        //public virtual ICollection<Bitacora> Bitacoras { get; set; }
        //public virtual ICollection<Registro> Registros { get; set; }


        //función para agregar un usuario a la base de datos
        public async Task<bool> AgregarUsurio()
        {
            try
            {
                string RouteSufix = string.Format("Usuarios");
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //tenemos que serializar la clase para poderla enviar al api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

        public async Task<bool> ValidarLogin()
        {
            try
            {
                string RouteSufix = string.Format("Usuarios/ValidarLogin?NombreUsuario={0}&ContraseniaUsuario={1}", 
                                                  this.Email, this.Contraseña);

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
                    return true;
                }
                else
                {
                    return false;
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
