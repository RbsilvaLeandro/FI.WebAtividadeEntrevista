using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        public ActionResult Incluir(int Id)
        {
            Session["IdCliente"] = Id;          
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (bo.VerificarExistencia(model.CPF))
                {
                    Response.StatusCode = 400;
                    return Json("CPF já cadastrado");
                }
                else
                {
                    if (bo.ValidaCPF(model.CPF))
                    {
                        model.Id = bo.Incluir(new Beneficiario()
                        {
                            CPF = model.CPF,
                            Nome = model.Nome,
                            IdCliente = (int)Session["IdCliente"]
                        });                        
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return Json("CPF inválido");
                    }
                }

                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (bo.ValidaCPF(model.CPF))
                {
                    bo.Alterar(new Beneficiario()
                    {
                        Id = model.Id,
                        CPF = model.CPF,
                        Nome = model.Nome,
                        IdCliente = model.IdCliente
                    });
                }
                else
                {
                    return Json("CPF Inválido");
                }

                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoBeneficiario bo = new BoBeneficiario();
            Beneficiario benefic = bo.Consultar(id);
            Models.BeneficiarioModel model = null;

            if (benefic != null)
            {
                model = new BeneficiarioModel()
                {
                    Id = benefic.Id,
                    CPF = benefic.CPF,
                    Nome = benefic.Nome,
                    IdCliente = benefic.IdCliente
                };
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult BeneficiarioList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');
               
                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Beneficiario> benefic = new BoBeneficiario().Pesquisa((int)Session["IdCliente"], jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = benefic, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            BoBeneficiario bo = new BoBeneficiario();
            bo.Excluir(id);

            return Json("Cadastro excluído com sucesso");
        }
    }
}