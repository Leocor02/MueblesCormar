using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MueblesCormar.Models;

namespace MueblesCormar.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public RolUsuario MyRolUsuario { get; set; }
        public Usuario MyUsuario { get; set; }

        public UserViewModel()
        {
            MyRolUsuario = new RolUsuario();
            MyUsuario = new Usuario();
        }

        public async Task<List<RolUsuario>> GetRolUsuarioLista()
        {
            try
            {
                List<RolUsuario> list = new List<RolUsuario>();

                list = await MyRolUsuario.GetRolesUsurios();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }


        //función para agregar usuario
        public async Task<bool> AgregarNuevoUsuario(string pName,
                                                    string pEmail,
                                                    string pContraseña,
                                                    string pTelefono,
                                                    int pRolUsuario = 2) //Usuario empleado
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUsuario.Nombre = pName;
                MyUsuario.Email = pEmail;
                MyUsuario.Contraseña = pContraseña;
                MyUsuario.Telefono = pTelefono;
                MyUsuario.IdrolUsuario = pRolUsuario;

                bool R = await MyUsuario.AgregarUsurio();

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally 
            { 
                IsBusy = false;
            }


            
        }
    }
}
