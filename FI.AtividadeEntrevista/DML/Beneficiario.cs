namespace FI.AtividadeEntrevista.DML
{
    /// <summary>
    /// Classe de beneficiarios que representa o registo na tabela beneficiarios do Banco de Dados
    /// </summary>
    public class Beneficiario
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        public string CPF { get; set; }


        /// <summary>
        /// NOME
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// IdCliente
        /// </summary>
        public long IdCliente { get; set; }
    }
}
