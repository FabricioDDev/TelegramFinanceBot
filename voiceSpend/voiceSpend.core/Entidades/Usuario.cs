using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceSpend.Dominio.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string? NombreUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new();
    }
}
