// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ingresa la opcion \n " +
    "1- Agregar paciente," +
    "\n 2-Borrar paciente," +
    "\n 3-Actualizar paciente," +
    "\n 4-Buscar todos los pacientes," +
    "\n 5-Buscar por id al paciente"+
    "\n 6-Agregar receta,"+
    "\n 7-Borrar receta," +
    "\n 8-Actualizar receta," +
    "\n 9-Buscar todas las recetas," +
    "\n 10-Buscar por id la receta" );
int opcion = int.Parse(Console.ReadLine());
switch (opcion)
{
    case 1:
        PL.Paciente.Add();
        Console.ReadKey();
        break;
    case 2:
        PL.Paciente.Delete();
        Console.ReadKey();
        break;
    case 3:
        PL.Paciente.Update();
        Console.ReadKey();
        break;
    case 4:
        PL.Paciente.GetAll();
        Console.ReadKey();
        break;
    case 5:
        PL.Paciente.GetById();
        Console.ReadKey();
        break;
    case 6:
        PL.RecetaMedica.Add();
        Console.ReadKey();
        break;
    case 7:
        PL.RecetaMedica.Delete();
        Console.ReadKey();
        break;
    case 8:
        PL.RecetaMedica.Update();
        Console.ReadKey();
        break;
    case 9:
        PL.RecetaMedica.GetAll();
        Console.ReadKey();
        break;
    case 10:
        PL.RecetaMedica.GetById();
        Console.ReadKey();
        break;
    default:
        break;
}
