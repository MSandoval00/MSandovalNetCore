using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class RecetaMedica
    {
        public static void Add()
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            Console.WriteLine("Ingresa id paciente");
            recetaMedica.Paciente = new ML.Paciente();
            recetaMedica.Paciente.IdPaciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la fecha");
            recetaMedica.FechaConsulta = Console.ReadLine();
            Console.WriteLine("Ingresa el diagnostico");
            recetaMedica.Diagnostico = Console.ReadLine();
            Console.WriteLine("Ingresa el nombre del medico");
            recetaMedica.NombreMedico = Console.ReadLine();
            Console.WriteLine("Ingresa las notas adicionales");
            recetaMedica.NotasAdicionales=Console.ReadLine();
            ML.Result result = BL.RecetaMedica.Add(recetaMedica);
            if (result.Correct)
            {
                Console.WriteLine("Receta agregada exitosamente");
            }
            else
            {
                Console.WriteLine("Receta no agregada");
            }
        }
        public static void Update()
        {
            ML.RecetaMedica recetaMedica=new ML.RecetaMedica();
            Console.WriteLine("Ingresa id de la receta a actualizar");
            recetaMedica.IdReceta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa id del paciente a modificar");
            recetaMedica.Paciente=new ML.Paciente();
            recetaMedica.Paciente.IdPaciente=int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la fecha");
            recetaMedica.FechaConsulta = Console.ReadLine();
            Console.WriteLine("Ingresa Diagnostico");
            recetaMedica.Diagnostico=Console.ReadLine();
            Console.WriteLine("Ingresa el nombre del medico");
            recetaMedica.NombreMedico=Console.ReadLine();
            Console.WriteLine("Ingresa las notas adicionales");
            recetaMedica.NotasAdicionales = Console.ReadLine();
            ML.Result result = BL.RecetaMedica.Update(recetaMedica);
            if (result.Correct)
            {
                Console.WriteLine("Receta Actualizada");
            }
            else
            {
                Console.WriteLine("No se pudo actualizar la receta"+result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            Console.WriteLine("Ingresa el id de receta a eliminar");
            recetaMedica.IdReceta=int.Parse(Console.ReadLine());
            ML.Result result = BL.RecetaMedica.Delete(recetaMedica.IdReceta);
            if (result.Correct)
            {
                Console.WriteLine("Receta eliminada");
            }
            else
            {
                Console.WriteLine("Receta no eliminada");
            }
        }
        public static void GetAll()
        {
            ML.Result result= BL.RecetaMedica.GetAll();
            if (result.Correct)
            {
                foreach (ML.RecetaMedica recetaMedica in result.Objects)
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("IdReceta:" + recetaMedica.IdReceta);
                    Console.WriteLine("IdPaciente:" + recetaMedica.Paciente.IdPaciente);
                    Console.WriteLine("NombrePaciente:" + recetaMedica.NombreMedico.ToString());
                    Console.WriteLine("FechaConsulta:" + recetaMedica.FechaConsulta);
                    Console.WriteLine("Diagnostico:" + recetaMedica.Diagnostico);
                    Console.WriteLine("Nombre de medico:" + recetaMedica.NombreMedico);
                    Console.WriteLine("Notas adicionales:" + recetaMedica.NotasAdicionales);
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
            Console.WriteLine("Ingresa el id de la receta");
            int idreceta = int.Parse(Console.ReadLine());
            ML.Result result = BL.RecetaMedica.GetById(idreceta);
            if (result.Correct)
            {
                ML.RecetaMedica recetaMedica =(ML.RecetaMedica)result.Object;
                Console.WriteLine("**********************************************");
                Console.WriteLine("IdReceta:" + recetaMedica.IdReceta);
                Console.WriteLine("IdPaciente:" + recetaMedica.Paciente.IdPaciente);
                Console.WriteLine("NombrePaciente:" + recetaMedica.NombreMedico.ToString());
                Console.WriteLine("FechaConsulta:" + recetaMedica.FechaConsulta);
                Console.WriteLine("Diagnostico:" + recetaMedica.Diagnostico);
                Console.WriteLine("Nombre de medico:" + recetaMedica.NombreMedico);
                Console.WriteLine("Notas adicionales:" + recetaMedica.NotasAdicionales);
                Console.WriteLine("**********************************************");
            }
            else
            {
                Console.WriteLine("Error" +result.ErrorMessage);
            }
        }
            

        
    }
}
