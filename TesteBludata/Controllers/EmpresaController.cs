using System;
using System.Net;
using System.Web.Mvc;
using TesteBludata.Business;
using TesteBludata.Model;

namespace TesteBludata.Controllers
{
    public class EmpresaController : Controller
    {
        public EmpresaController()
        {
        }

        public ActionResult Index()
        {
            try
            {
                return View(new Empresa().Consultar());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Index"));
            }
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.Empresas = new Empresa().Consultar();

                return View(new EmpresaViewModel());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Create"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empresa = new EmpresaModel();
                    empresa.NomeFantasia = model.NomeFantasia;
                    empresa.Estado = model.Estado;
                    empresa.CNPJ = model.CNPJ;
                    new Empresa().Incluir(empresa);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Create"));
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                var negocio = new Empresa();
                EmpresaModel empresa = negocio.ConsultarPeloID(id);
                if (empresa == null)
                    return HttpNotFound();

                ViewBag.Empresas = negocio.Consultar();

                return View(empresa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Edit"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, NomeFantasia, Estado, CNPJ")] EmpresaModel model)
        {
            try
            {
                var negocio = new Empresa();

                if (ModelState.IsValid)
                {
                    var empresa = negocio.ConsultarPeloID(model.ID);
                    if (empresa == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    empresa.NomeFantasia = model.NomeFantasia;
                    empresa.Estado = model.Estado;
                    empresa.CNPJ = model.CNPJ;
                    negocio.Alterar(empresa, empresa.ID);

                    return RedirectToAction("Index");
                }

                ViewBag.Empresas = negocio.Consultar();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Edit"));
            }
        }

        public ActionResult Delete(long id)
        {
            try
            {
                var negocio = new Empresa();
                var empresa = negocio.ConsultarPeloID(id);
                if (empresa == null)
                    return HttpNotFound();

                ViewBag.Empresa = empresa.NomeFantasia;
                return View(empresa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Delete"));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var negocio = new Empresa();
                var empresa = negocio.ConsultarPeloID(id);
                negocio.Excluir(empresa);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmpresaController", "Delete"));
            }
        }

    }
}