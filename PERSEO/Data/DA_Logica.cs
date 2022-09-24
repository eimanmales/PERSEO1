using Microsoft.CodeAnalysis.CSharp.Syntax;
using PERSEO.Models;

namespace PERSEO.Data
{
    public class DA_Logica
    {
        public List<Usuario> listaUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario{Nombre = "Eiman", Correo = "eiman@correo.com", Clave = "123", Roles = new string[]{"Administrador"} },
                 new Usuario{Nombre = "Jose", Correo = "vendedor@correo.com", Clave = "123", Roles = new string[]{"Empleado"} },
                  new Usuario{Nombre = "Gabi", Correo = "supervisora@correo.com", Clave = "123", Roles = new string[]{"Supervisor"} },
                   new Usuario{Nombre = "Emily", Correo = "superempleado@correo.com", Clave = "123", Roles = new string[]{"Supervisor", "Empleado"} }
            };
        }

        public Usuario validarUsuario(string _correo, string _clave)
        {
            return listaUsuarios().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }
    }
}
