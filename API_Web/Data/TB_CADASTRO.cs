using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Data
{
    [Table("TB_CADASTRO")]  
    public class TB_CADASTRO
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Column("nome")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [Column("email")]
        public string Email { get; set; }

        [Display(Name = "Endereco")]
        [Column("endereco")]
        public string Endereco { get; set; }
        
    }
}
