using System.ComponentModel.DataAnnotations;

namespace Banco.MVC.Enum
{
    public enum TipoModalidade
    {
        [Display(Name = "Conta Corrente")]
        ContaCorrente = 1,
        [Display(Name = "Conta Poupança")]
        ContaPoupança = 2
    }
}