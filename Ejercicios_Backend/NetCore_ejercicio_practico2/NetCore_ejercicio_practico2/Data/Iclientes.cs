using NetCore_ejercicio_practico2.Model;

namespace NetCore_ejercicio_practico2.Data
{
    public interface Iclientes
    {
        Task<IEnumerable<clienteModel>> leerclientes();
        Task<clienteModel> leerclientesxid(int id);
        Task<clienteModel> leerclientesxnombre(String nombre);
        Task<clienteModel> leerclientesxedad(int edad);

    }
}
