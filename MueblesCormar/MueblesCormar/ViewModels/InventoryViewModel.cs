using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public Inventario MiInventario { get; set; }
        public InventarioDTO MiInventarioDTO { get; set; }

        public InventoryViewModel()
        {
            MiInventario = new Inventario();
            MiInventarioDTO = new InventarioDTO();
        }

        //función para agregar un producto
        public async Task<bool> AgregarNuevoProducto(string pNombre,
                                            int pCantidad,
                                            string pDescripcion,
                                            string pImagenProducto,
                                            int pPrecioUnidad)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiInventario.Nombre = pNombre;
                MiInventario.Cantidad = pCantidad;
                MiInventario.Descripcion = pDescripcion;
                MiInventario.ImagenProducto = pImagenProducto;
                MiInventario.PrecioUnidad = pPrecioUnidad;

                bool R = await MiInventario.AgregarProducto();

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

        //función para actualizar usuario
        public async Task<bool> ActualizarProducto(int idProducto,
                                                  string pNombre,
                                                  int pCantidad,
                                                  string pDescripcion,
                                                  string pImagenProducto,
                                                  int pPrecio)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiInventarioDTO.Idproducto = idProducto;
                MiInventarioDTO.Nombre = pNombre;
                MiInventarioDTO.Cantidad = pCantidad;
                MiInventarioDTO.Descripcion = pDescripcion;
                MiInventarioDTO.ImagenProducto = pImagenProducto;
                MiInventarioDTO.PrecioUnidad = pPrecio;


                bool R = await MiInventarioDTO.ActualizarProducto(idProducto);

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

        public async Task<InventarioDTO> GetDataProducto(int idProducto)
        {
            try
            {
                InventarioDTO producto = new InventarioDTO();

                producto = await MiInventarioDTO.GetDataProducto(idProducto);

                if (producto == null)
                {
                    return null;
                }
                else
                {
                    return producto;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<InventarioDTO>> GetFullListaInventario()
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
                    ObservableCollection<InventarioDTO> list = new ObservableCollection<InventarioDTO>();

                    list = await MiInventarioDTO.GetListaInventario();

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

        public async Task<bool> DeleteProducto(int idProducto)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiInventarioDTO.DeleteProducto(idProducto);
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
