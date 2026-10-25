using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceSpend.Dominio.Entidades
{
    internal class EstadoTransaccion
    {
        public enum EstadoTrans
        {
            Pendiente,
            Confirmado,
            Cancelado,
            Eliminado
        }
    }
}
