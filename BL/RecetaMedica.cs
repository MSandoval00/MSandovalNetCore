using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetaMedica
    {
        public static ML.Result Add(ML.RecetaMedica recetaMedica)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"RecetasMedicasAdd '{recetaMedica.Paciente.IdPaciente}','{recetaMedica.FechaConsulta}',{recetaMedica.Diagnostico},{recetaMedica.NombreMedico},{recetaMedica.NotasAdicionales}");
                    if (query>=1)
                    {
                        result.Correct=true;
                        //Console.WriteLine("Receta Medica agregada");

                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "Error no se agrego la receta medica";
                        //Console.WriteLine("Error no se agrego la receta medica");
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result Update(ML.RecetaMedica recetaMedica) 
        {
            ML.Result result =new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RecetasMedicasUpdate '{recetaMedica.IdReceta}','{recetaMedica.Paciente.IdPaciente}','{recetaMedica.FechaConsulta}',{recetaMedica.Diagnostico},{recetaMedica.NombreMedico},{recetaMedica.NotasAdicionales}");
                    if (query>0)
                    {
                        //Console.WriteLine("Receta actualizada");
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error no se actualizo la receta";
                        //Console.WriteLine("Error no se actualizo la receta");
                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
                throw;
            }
            return result;
        
        }
        public static ML.Result Delete(int IdReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RecetasMedicasDelete '{IdReceta}'");
                    if (query>0)
                    {
                        //Console.WriteLine("Receta eliminada");
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar la receta";
                        //Console.WriteLine("Error la receta no fue eliminada");
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex=ex;
            }
            return result;

        }
        public static ML.Result GetAll()
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context = new DL.MsandovalNetCoreContext())
                {
                    var query = context.RecetasMedicas.FromSqlRaw("RecetasMedicasGetAll").ToList();
                    result.Objects = new List<object>();
                    if (query!=null)
                    {
                        foreach (var row in query)
                        {
                            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
                            recetaMedica.IdReceta = row.IdReceta;
                            recetaMedica.Paciente = new ML.Paciente();
                            recetaMedica.Paciente.IdPaciente = int.Parse(row.IdPaciente.ToString());
                            recetaMedica.Paciente.Nombre=row.NombrePaciente;
                            recetaMedica.FechaConsulta = row.FechaConsulta.Value.ToString("yyyy-MM-dd");
                            recetaMedica.Diagnostico=row.Diagnostico;
                            recetaMedica.NombreMedico=row.NombreMedico;
                            recetaMedica.NotasAdicionales = row.NotasAdicionales;
                            
                            result.Objects.Add(recetaMedica);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros por mostrar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdReceta)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context =new DL.MsandovalNetCoreContext())
                {
                    var query = context.RecetasMedicas.FromSqlRaw($"RecetasMedicasGetById '{IdReceta}'").AsEnumerable().SingleOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.RecetaMedica recetaMedica=new ML.RecetaMedica();
                        recetaMedica.IdReceta = query.IdReceta;
                        recetaMedica.Paciente = new ML.Paciente();
                        recetaMedica.Paciente.IdPaciente=int.Parse(query.IdPaciente.ToString());
                        recetaMedica.Paciente.Nombre=query.NombrePaciente;
                        recetaMedica.FechaConsulta = query.FechaConsulta.Value.ToString("yyyy-MM-dd");
                        recetaMedica.Diagnostico = query.Diagnostico;
                        recetaMedica.NombreMedico=query.NombreMedico;
                        recetaMedica.NotasAdicionales=query.NotasAdicionales;
                        result.Object=recetaMedica;
                        result.Correct = true;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
       
            }
            return result;
        }
    }
}
