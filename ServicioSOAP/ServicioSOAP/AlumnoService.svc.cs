using ServicioSOAP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public bool Actualizar(string dni, string nombre, string domicilio, string ciudad)
        {
            bool resultado = false;
            Alumno alumno = new Alumno
            {
                Dni = dni,
                Nombre = nombre,
                Domicilio = domicilio,
                Ciudad = ciudad
            };
            using (AlumnosPruebaEntities db = new AlumnosPruebaEntities())
            {
                db.Entry(alumno).State = EntityState.Modified;
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public bool Agregar(string dni, string nombre, string domicilio, string ciudad)
        {
            bool resultado = false;
            Alumno alumno = new Alumno
            {
                Dni = dni,
                Nombre = nombre,
                Domicilio = domicilio,
                Ciudad = ciudad
            };
            using (AlumnosPruebaEntities db = new AlumnosPruebaEntities())
            {
                db.Alumnoes.Add(alumno);
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public Alumno BuscarXDni(string dni)
        {
            using (AlumnosPruebaEntities db = new AlumnosPruebaEntities())
            {
                return db.Alumnoes.FirstOrDefault(x => x.Dni == dni);
            }
        }

        public List<Alumno> Consultar()
        {
            using (AlumnosPruebaEntities db = new AlumnosPruebaEntities())
            {
                return db.Alumnoes.ToList();
            }
        }

        public bool Eliminar(string dni)
        {
            bool resultado = false;
            using (AlumnosPruebaEntities db = new AlumnosPruebaEntities())
            {
                Alumno alumno = db.Alumnoes.FirstOrDefault(x => x.Dni == dni);
                if (alumno != null)
                {
                    db.Alumnoes.Remove(alumno);
                    resultado = db.SaveChanges() > 0;
                }
                else
                {
                    resultado = false;
                }
                return resultado;
            }
        }
    }
}
