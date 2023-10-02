using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class RecetaMedica : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result=BL.RecetaMedica.GetAll();
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            recetaMedica.RecetasMedicas=new List<object>();
            if (result.Correct)
            {
                recetaMedica.RecetasMedicas = result.Objects;

            }
            else
            {
                ViewBag.Mensaje = result.ErrorMessage;
            }
            
            return View(recetaMedica);
        }
        [HttpGet]
        public IActionResult Form(int? IdReceta)
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();

            ML.Result resultPaciente = BL.Paciente.GetAll();
            recetaMedica.Paciente = new ML.Paciente();

            if (IdReceta!=null)//Update
            {
                ML.Result result = BL.RecetaMedica.GetById(IdReceta.Value);
                if (result.Correct)
                {
                    recetaMedica = (ML.RecetaMedica)result.Object;
                    recetaMedica.RecetasMedicas = resultPaciente.Objects;
                }

            }
            else
            {

                recetaMedica.RecetasMedicas = resultPaciente.Objects;
            }
            return View(recetaMedica);
        }
        [HttpPost]
        public IActionResult Form(ML.RecetaMedica recetaMedica)
        {
            if (recetaMedica.IdReceta==0)//add
            {
                ML.Result result = BL.RecetaMedica.Add(recetaMedica);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se agrego correctamente la receta";

                }
                else
                {
                    ViewBag.Mensaje = "No se agrego la receta";
                }
            }
            else {
                ML.Result result = BL.RecetaMedica.Update(recetaMedica);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se actualizo correctamente la receta";
                }
                else
                {
                    ViewBag.Mensaje = "No se actualizo la receta";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public IActionResult Delete(int IdReceta)
        {
            ML.Result result = BL.RecetaMedica.Delete(IdReceta);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino la receta correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se elimino la receta";
            }
            return PartialView("Modal");

        }
    }
}
