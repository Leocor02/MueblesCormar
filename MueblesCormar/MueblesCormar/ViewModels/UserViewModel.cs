using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public RolUsuario MiRolUsuario { get; set; }
        public Usuario MiUsuario { get; set; }
        public UsuarioDTO MiUsuarioDTO { get; set; }

        public UserViewModel()
        {
            MiRolUsuario = new RolUsuario();
            MiUsuario = new Usuario();
            MiUsuarioDTO = new UsuarioDTO();
        }

        public async Task<List<RolUsuario>> GetRolUsuarioLista()
        {
            try
            {
                List<RolUsuario> list = new List<RolUsuario>();

                list = await MiRolUsuario.GetRolesUsurios();

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
                                                    int rolID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuario.Nombre = pName;
                MiUsuario.Email = pEmail;
                MiUsuario.Contraseña = pContraseña;
                MiUsuario.Telefono = pTelefono;
                MiUsuario.IdrolUsuario = rolID;

                bool R = await MiUsuario.AgregarUsuario();

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

        //función de validación de ingreso del usuario al app
        public async Task<bool> AccesoValidacionUsuario(string pEmail, string pContraseña)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuario.Email = pEmail;
                MiUsuario.Contraseña = pContraseña;

                bool R = await MiUsuario.ValidarLogin();

                return R;
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            { IsBusy = false; }
                
            
        }

        //función para actualizar usuario
        public async Task<bool> ActualizarUsuario(string pName,
                                                   string pEmail,
                                                   string pContraseña,
                                                   string pTelefono)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuarioDTO.Nombre = pName;
                MiUsuarioDTO.Email = pEmail;
                MiUsuarioDTO.Contrasennia = pContraseña;
                MiUsuarioDTO.Telefono = pTelefono;
          

                bool R = await MiUsuarioDTO.ActualizarUsuario();

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
