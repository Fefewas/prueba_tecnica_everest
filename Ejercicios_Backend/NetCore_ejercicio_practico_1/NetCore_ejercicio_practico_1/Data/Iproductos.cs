using NetCore_ejercicio_practico_1.Models;

namespace NetCore_ejercicio_practico_1.Data
{
    public interface Iproductos
    {
        Task<IEnumerable<producto>> LeerProductos();
        Task<producto> leerDetalles(int id);
        Task<bool> agregarProducto(producto producto);
        Task<bool> actualizarProducto(producto producto);
        Task<bool> eliminarProducto(producto producto);

    }
}
