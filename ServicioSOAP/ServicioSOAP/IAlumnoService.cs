using ServicioSOAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]
        bool Actualizar(string dni, string nombre, string domicilio, string ciudad);
        [OperationContract]
        bool Agregar(string dni, string nombre, string domicilio, string ciudad);
        [OperationContract]
        Alumno BuscarXDni(string dni);
        [OperationContract]
        List<Alumno> Consultar();
        [OperationContract]
        bool Eliminar(string dni);
    }
}
