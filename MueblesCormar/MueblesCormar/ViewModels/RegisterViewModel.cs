using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegistroDTO MiRegistroDTO { get; set; }


        public RegisterViewModel()
        {
            MiRegistroDTO = new RegistroDTO();
        }

        public async Task<bool> AddRegistro(DateTime pFecha,
                                            string pNota,
                                            int pIdUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiRegistroDTO.Fecha = pFecha;
                MiRegistroDTO.Nota = pNota;
                MiRegistroDTO.Idusuario = pIdUsuario;

                bool R = await MiRegistroDTO.AddRegistro();

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

        public async Task<RegistroDTO> GetDataRegistro(int idRegistro)
        {
            try
            {
                RegistroDTO proveedor = new RegistroDTO();

                proveedor = await MiRegistroDTO.GetDataRegistro(idRegistro);

                if (proveedor == null)
                {
                    return null;
                }
                else
                {
                    return proveedor;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<RegistroDTO>> GetFullListaRegistro()
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
                    ObservableCollection<RegistroDTO> list = new ObservableCollection<RegistroDTO>();

                    list = await MiRegistroDTO.GetListaRegistro();

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

        public async Task<bool> DeleteRegistro(int idRegistro)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiRegistroDTO.DeleteRegistro(idRegistro);

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


    }
}
