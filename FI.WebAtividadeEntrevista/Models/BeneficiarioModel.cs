using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe modelo de cliente
    /// </summary>
    public class BeneficiarioModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        ///
        [Required]
        public string CPF { get; set; }


        /// <summary>
        /// NOME
        /// </summary>
        /// 
        [Required]
        public string Nome { get; set; }


        /// <summary>
        /// IdCliente
        /// </summary>               
        public long IdCliente { get; set; }
    }
}