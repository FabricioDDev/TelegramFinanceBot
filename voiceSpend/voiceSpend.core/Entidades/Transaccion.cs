using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceSpend.Dominio.Entidades
{
    internal class Transaccion
    {
        public int IdTransaccion { get; set; }
        public long IdUsuarioTelegram { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Concepto { get; set; } = "";
        public DateOnly Fecha { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public EstadoTransaccion Estado { get; set; }
        public long MessageId { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
