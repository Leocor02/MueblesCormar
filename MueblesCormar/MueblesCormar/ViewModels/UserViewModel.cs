using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<UsuarioDTO> GetDataUsuario(string email)
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();

                usuario = await MiUsuarioDTO.GetDataUsuario(email);

                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            catch (Exception)
            {

                return null;
            }
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
        public async Task<bool> AddUsuario(string pNombre,
                                           string pEmail,
                                           string pContraseña,
                                           string pTelefono,
                                           int rolID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuario.Nombre = pNombre;
                MiUsuario.Email = pEmail;
                MiUsuario.Contraseña = pContraseña;
                MiUsuario.Telefono = pTelefono;
                MiUsuario.IdrolUsuario = rolID;

                bool R = await MiUsuario.AddUsuario();

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

        //Función para eliminar un empleado
        public async Task<bool> DeleteEmpleado(int idUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiUsuarioDTO.DeleteEmpleado(idUsuario);

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }

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

        public async Task<UsuarioDTO> GetDataEmpleado(int idUsuario)
        {
            try
            {
                UsuarioDTO empleado = new UsuarioDTO();

                empleado = await MiUsuarioDTO.GetDataEmpleado(idUsuario);

                if (empleado == null)
                {
                    return null;
                }
                else
                {
                    return empleado;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<UsuarioDTO>> GetFullListaEmpleado()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<UsuarioDTO> list = new ObservableCollection<UsuarioDTO>();

                    list = await MiUsuarioDTO.GetListaEmpleado();

                    if (list == null)
                    {
                        return null;
                    }

                    return list;

                }
                catch (Exception)
                {
                    return null;
                }
                finally { IsBusy = false; }

            }

        }

        //función para actualizar usuario
        public async Task<bool> UpdateUsuario(int idUsuario, 
                                              string pNombre, 
                                              string pEmail,
                                              //string pContrasennia,
                                              string pTelefono)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuarioDTO.Idusuario = idUsuario;
                MiUsuarioDTO.Nombre = pNombre;
                MiUsuarioDTO.Email = pEmail;
                //MiUsuarioDTO.Contrasennia = pContrasennia;
                MiUsuarioDTO.Telefono = pTelefono;

                bool R = await MiUsuarioDTO.UpdateUsuario(idUsuario);

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
