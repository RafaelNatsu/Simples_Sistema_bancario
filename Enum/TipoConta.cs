using System.ComponentModel.DataAnnotations;

namespace Banco.MVC.Enum
{
    public enum TipoConta
    {
        [Display(Name = "Pessoa Fisica")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Juridica")]
        PessoaJuridica = 2
    }
}