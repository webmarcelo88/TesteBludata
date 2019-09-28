using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using TesteBludata.Business;
using TesteBludata.Model;

namespace TesteBludata.Controllers
{
    public class FornecedorController : Controller
    {
        public FornecedorController()
        {
        }

        public ActionResult Index(string filtro)
        {
            try
            {
                return View(new Fornecedor().ConsultarPeloFiltro(filtro));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Index"));
            }
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.Fornecedores = new Fornecedor().Consultar();

                return View(new FornecedorViewModel());
            }
            catch (BusinessException ex)
            {
                ViewBag.Message = ex.Message;
                return View(new FornecedorViewModel());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Create"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fornecedor = new FornecedorModel();
                    fornecedor.Nome = model.Nome;
                    fornecedor.CPFCNPJ = model.CPFCNPJ;
                    fornecedor.DataCadastro = DateTime.Now;
                    fornecedor.DataNascimento = model.DataNascimento;
                    fornecedor.Empresa = model.Empresa;
                    fornecedor.RG = model.RG;
                    fornecedor.Tipo = model.Tipo;
                    new Fornecedor().Incluir(fornecedor);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (BusinessException ex)
            {
                ViewBag.Message = ex.Message;
                return View(new FornecedorModel());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Create"));
            }            
        }

        public ActionResult Edit(long id)
        {
            try
            {
                var negocio = new Fornecedor();
                var fornecedor = negocio.ConsultarPeloID(id);
                if (fornecedor == null)
                    return HttpNotFound();

                ViewBag.Fornecedores = negocio.Consultar();

                return View(fornecedor);
            }
            catch (BusinessException ex)
            {
                ViewBag.Message = ex.Message;
                return View(new FornecedorModel());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Edit"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Nome, CPFCNPJ, DataCadastro, DataNascimento, Empresa, RG, Tipo")] FornecedorModel model)
        {
            try
            {
                var negocio = new Fornecedor();

                if (ModelState.IsValid)
                {
                    var fornecedor = negocio.ConsultarPeloID(model.ID);
                    if (fornecedor == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    fornecedor.Nome = model.Nome;
                    fornecedor.CPFCNPJ = model.CPFCNPJ;
                    fornecedor.DataCadastro = model.DataCadastro;
                    fornecedor.DataNascimento = model.DataNascimento;
                    fornecedor.Empresa = model.Empresa;
                    fornecedor.RG = model.RG;
                    fornecedor.Tipo = model.Tipo;
                    negocio.Alterar(fornecedor, fornecedor.ID);

                    return RedirectToAction("Index");
                }

                ViewBag.Fornecedores = negocio.Consultar();

                return View(model);
            }
            catch (BusinessException ex)
            {
                ViewBag.Message = ex.Message;
                return View(new FornecedorModel());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Edit"));
            }
        }

        public ActionResult Delete(long id)
        {
            try
            {
                var negocio = new Fornecedor();
                var fornecedor = negocio.ConsultarPeloID(id);
                if (fornecedor == null)
                    return HttpNotFound();

                ViewBag.Fornecedor = fornecedor.Nome;
                return View(fornecedor);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Delete"));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var negocio = new Fornecedor();
                var fornecedor = negocio.ConsultarPeloID(id);
                negocio.Excluir(fornecedor);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Delete"));
            }
        }

        public ActionResult Telefones(long fornecedor)
        {
            try
            {
                return View(new FornecedorTelefone().ConsultarPeloFornecedor(fornecedor));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "Telefones"));
            }
        }

        public ActionResult CreateTelefone(long fornecedor)
        {
            try
            {
                ViewBag.Telefones = new FornecedorTelefone().ConsultarPeloFornecedor(fornecedor);

                var model = new FornecedorTelefoneViewModel();
                model.Fornecedor = fornecedor;
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "CreateTelefone"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTelefone(FornecedorTelefoneViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var telefone = new FornecedorTelefoneModel();
                    telefone.Fornecedor = model.Fornecedor;
                    telefone.Telefone = model.Telefone;

                    var negocio = new FornecedorTelefone();
                    negocio.Incluir(telefone);

                    return RedirectToAction("Telefones", new { fornecedor = model.Fornecedor });
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "CreateTelefone"));
            }
        }

        public ActionResult EditTelefone(long id)
        {
            try
            {
                var negocio = new FornecedorTelefone();
                var telefone = negocio.ConsultarPeloID(id);

                if (telefone == null)
                    return HttpNotFound();

                ViewBag.Telefones = negocio.Consultar();

                return View(telefone);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "EditTelefone"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTelefone([Bind(Include = "ID, Fornecedor, Telefone")] FornecedorTelefoneModel model)
        {
            try
            {
                var negocio = new FornecedorTelefone();

                if (ModelState.IsValid)
                {
                    var telefone = negocio.ConsultarPeloID(model.ID);
                    if (telefone == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    telefone.Telefone = model.Telefone;
                    negocio.Alterar(telefone, telefone.ID);

                    return RedirectToAction("Telefones", new { fornecedor = telefone.Fornecedor });
                }

                ViewBag.Telefones = negocio.Consultar();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "EditTelefone"));
            }
        }

        public ActionResult DeleteTelefone(long id)
        {
            try
            {
                var negocio = new FornecedorTelefone();
                var telefone = negocio.ConsultarPeloID(id);
                if (telefone == null)
                    return HttpNotFound();

                ViewBag.Telefone = telefone.Telefone;
                return View(telefone);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "DeleteTelefone"));
            }
        }

        [HttpPost, ActionName("DeleteTelefone")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTelefoneConfirmed(int id)
        {
            try
            {
                var negocio = new FornecedorTelefone();
                var telefone = negocio.ConsultarPeloID(id);
                negocio.Excluir(telefone);

                return RedirectToAction("Telefones", new { fornecedor = telefone.Fornecedor });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "FornecedorController", "DeleteTelefone"));
            }
        }
    }
}