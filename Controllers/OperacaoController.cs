using Banco.MVC.Models;
using Banco.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Banco.MVC.Controllers
{
    public class OperacaoController : Controller
    {
        private readonly ContaContext _context;
        public OperacaoController(ContaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Saque(){
            return View();
        }

        public IActionResult Deposito(){
            return View();
        }

        public IActionResult Tranferencia(){   
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Saque(string nomeCliente, double valorSaque){
            
            try
            {
                Conta cliente = _context.Conta.Where<Conta>(m => m.Nome == nomeCliente).First<Conta>();
                if(HasSaldo(cliente)){
                    if (cliente.Saldo>=valorSaque)
                    {
                        cliente.Saldo -= valorSaque;
                    }
                    else
                    {
                        double resto = cliente.Saldo - valorSaque;
                        cliente.Saldo=0;
                        cliente.Credito -= -(resto);
                    }
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.ArgumentNullException)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposito(string nomeCliente, double valorDepositar)
        {
            try
            {
                Conta cliente = _context.Conta.Where<Conta>(m => m.Nome == nomeCliente).First<Conta>();
                cliente.Saldo += valorDepositar;
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (System.ArgumentNullException)
            {
                throw;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tranferencia(string nomePagante, string nomeFavorecido, double valorPagar){
            Conta Pagante = _context.Conta.Where<Conta>(m => m.Nome == nomePagante).First<Conta>();
            Conta Favorecido = _context.Conta.Where<Conta>(m => m.Nome == nomeFavorecido).First<Conta>();
            if (Pagante.Equals(Favorecido))
            {
                return BadRequest();
            }
            else if (!HasSaldo(Pagante)&&(!HasCredito(Pagante)))
            {
                return BadRequest();
            }
            else
            {
                if (HasSaldo(Pagante))
                {
                    if (Pagante.Saldo>=valorPagar)
                    {
                         Pagante.Saldo -= valorPagar;
                    }
                    else
                    {
                        double resto = Pagante.Saldo - valorPagar;
                        Pagante.Saldo=0;
                        Pagante.Credito -= -(resto);
                    }
                   
                    Favorecido.Saldo += valorPagar;
                    _context.Update(Pagante);
                    _context.Update(Favorecido);
                    await _context.SaveChangesAsync();
                }else{
                    Pagante.Credito -= valorPagar;
                    Favorecido.Saldo += valorPagar;
                    _context.Update(Pagante);
                    _context.Update(Favorecido);
                    await _context.SaveChangesAsync();
                }
                    
            }
            return RedirectToAction("Index");
        }


        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }

        private bool HasSaldo(Conta verifica){
            return _context.Conta.Any(e => e.Saldo > 0);
        }
        private bool HasCredito(Conta verifica){
            return _context.Conta.Any(e => e.Credito > 0);
        }
    }
}
