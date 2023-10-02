using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PacienteAdd {paciente.Nombre},{paciente.ApellidoPaterno},{paciente.ApellidoMaterno}");
                    if (query>0)
                    {
                        Console.WriteLine("Paciente Insertado");
                    }
                    else
                    {
                        Console.WriteLine("Error no se inserto");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PacienteUpdate {paciente.IdPaciente},{paciente.Nombre},{paciente.ApellidoPaterno},{paciente.ApellidoMaterno}");
                    if (query>0)
                    {
                        Console.WriteLine("Paciente actualizado");
                    }
                    else
                    {
                        Console.WriteLine("Error no actualizado");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex=ex;
            }
            return result ;
        }
        public static ML.Result Delete(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context=new DL.MsandovalNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PacienteDelete '{IdPaciente}'");

                    if (query>0)
                    {
                        Console.WriteLine("Paciente borrado");
                    }
                    else
                    {
                        Console.WriteLine("Error no eliminado");
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context =new DL.MsandovalNetCoreContext())
                {
                    var query = context.Pacientes.FromSqlRaw($"PacienteGetAll").ToList();
                    result.Objects = new List<object>();
                    if (query!=null)
                    {
                        foreach (var row in query)
                        {
                            ML.Paciente paciente=new ML.Paciente();
                            paciente.IdPaciente=row.IdPaciente;
                            paciente.Nombre=row.Nombre;
                            paciente.ApellidoPaterno = row.ApellidoPaterno;
                            paciente.ApellidoMaterno=row.ApellidoMaterno;
                            result.Objects.Add(paciente);

                        }
                        result.Correct=true;

                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No hay registros de pacientes";
                        Console.WriteLine("No hay registros de pacientes");
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
        public static ML.Result GetById(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MsandovalNetCoreContext context = new DL.MsandovalNetCoreContext())
                {
                    var query = context.Pacientes.FromSqlRaw($"PacienteGetById '{IdPaciente}'").AsEnumerable().SingleOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre=query.Nombre;
                        paciente.ApellidoPaterno=query.ApellidoPaterno;
                        paciente.ApellidoMaterno=query.ApellidoMaterno;

                        result.Object = paciente;
                        result.Correct=true;
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
    }
}