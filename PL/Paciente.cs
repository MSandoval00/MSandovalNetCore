using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Paciente
    {
        public static void Add()
        {
            ML.Paciente paciente = new ML.Paciente();
            Console.WriteLine("Ingresa nombre del paciente");
            paciente.Nombre=Console.ReadLine();
            Console.WriteLine("Ingresa Apellido Paterno");
            paciente.ApellidoPaterno=Console.ReadLine();
            Console.WriteLine("Ingresa Apellido Materno");
            paciente.ApellidoMaterno=Console.ReadLine();

            ML.Result result=BL.Paciente.Add(paciente);
            if (result.Correct)
            {
                Console.WriteLine("Paciente agregado exitosamente");

            }
            else
            {
                Console.WriteLine("Paciente no agregado" +result.ErrorMessage);
            }
        }
        public static void Update()
        {
            ML.Paciente paciente = new ML.Paciente();
            Console.WriteLine("Ingresa el Id de paciente a actualizar");
            paciente.IdPaciente =int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo nombre del paciente");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo Apellido Paterno del paciente");
            paciente.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo Apellido Materno del paciente");
            paciente.ApellidoMaterno=Console.ReadLine();

            ML.Result result = BL.Paciente.Update(paciente);
            if (result.Correct)
            {
                Console.WriteLine("Campos actualizados correctamente");
            }
            else
            {
                Console.WriteLine("Campos no actualizados correctamente"+result.ErrorMessage);
            }

        }
        public static void Delete()
        {
            ML.Paciente paciente = new ML.Paciente();
            Console.WriteLine("Ingresa el id del paciente a eliminar");
            paciente.IdPaciente=int.Parse(Console.ReadLine());
            ML.Result result = BL.Paciente.Delete(paciente.IdPaciente);
            if (result.Correct)
            {
                Console.WriteLine("Paciente eliminado");
            }
            else
            {
                Console.WriteLine("Paciente no eliminado");
            }
        }
        public static void GetAll()
        {
            //ML.Paciente paciente=new ML.Paciente();
            ML.Result result=BL.Paciente.GetAll();
            if (result.Correct)
            {
                foreach (ML.Paciente paciente in result.Objects)
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("IdPaciente:"+paciente.IdPaciente);
                    Console.WriteLine("Nombre:"+paciente.Nombre);
                    Console.WriteLine("Apellido paterno:"+paciente.ApellidoPaterno);
                    Console.WriteLine("Apellido materno:"+paciente.ApellidoMaterno);
                    Console.WriteLine("**********************************************");
                    
                }
            }
            else
            {
                Console.WriteLine("Error"+result.ErrorMessage);
            }
        }
        public static void GetById()
        {
            Console.WriteLine("Ingresa el id del paciente");
            int idpaciente=int.Parse(Console.ReadLine());
            ML.Result result=BL.Paciente.GetById(idpaciente);
            if (result.Correct)
            {
                ML.Paciente paciente=(ML.Paciente)result.Object;
                Console.WriteLine("**********************************************");
                Console.WriteLine("IdPaciente:" + paciente.IdPaciente);
                Console.WriteLine("Nombre:" + paciente.Nombre);
                Console.WriteLine("Apellido paterno:" + paciente.ApellidoPaterno);
                Console.WriteLine("Apellido materno:" + paciente.ApellidoMaterno);
                Console.WriteLine("**********************************************");

            }
            else
            {
                Console.WriteLine("Error" +result.ErrorMessage);
            }
        }
    }
}
