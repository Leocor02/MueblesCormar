using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.ViewModels
{
    public class ProviderViewModel : BaseViewModel
    {
        public Proveedor MiProveedor { get; set; }
        public ProveedorDTO MiproveedorDTO { get; set; }

        public ProviderViewModel()
        {
            MiProveedor = new Proveedor();
            MiproveedorDTO = new ProveedorDTO();
        }

        public async Task<bool> AgregarNuevoProveedor(string pNombre,
                                                      string pDireccion)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiProveedor.Nombre = pNombre;
                MiProveedor.Direccion = pDireccion;
                

                bool R = await MiProveedor.AgregarProvedor();

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

        public async Task<ObservableCollection<ProveedorDTO>> GetFullListaProveedor()
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
                    ObservableCollection<ProveedorDTO> list = new ObservableCollection<ProveedorDTO>();

                    list = await MiproveedorDTO.GetListaProveedor();

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
    }
}
