using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            return benefic.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            benefic.Alterar(beneficiario);
        }

        /// <summary>
        /// Consulta o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            return benefic.Consultar(id);
        }
       
        /// <summary>
        /// Excluir o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            benefic.Excluir(id);
        }      

        /// <summary>
        /// Lista os beneficiarios pelo id de Cliente
        /// </summary>
        public List<DML.Beneficiario> Pesquisa(int IdCliente, int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            return benefic.Pesquisa(IdCliente, iniciarEm, quantidade, campoOrdenacao, crescente,  out qtd);
        }

        /// <summary>
        /// Verifica Existencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            return benefic.VerificarExistencia(CPF);
        }

        /// <summary>
        /// Verifica validade do CPF informado
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool ValidaCPF(string CPF)
        {
            DAL.DaoBeneficiario benefic = new DAL.DaoBeneficiario();
            return benefic.ValidaCPF(CPF);
        }


    }
}
