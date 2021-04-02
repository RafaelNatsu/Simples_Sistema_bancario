using Banco.MVC.Enum;
namespace Banco.MVC.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public TipoConta Tipoconta { get; set; }
        public TipoModalidade TipoModalidade { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }
        public string Nome { get; set; }
    }
}