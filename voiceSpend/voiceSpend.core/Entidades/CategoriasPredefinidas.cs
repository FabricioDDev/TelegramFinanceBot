using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceSpend.Dominio.Entidades
{
    public static class CategoriasPredefinidas
    {
        public const string Comida = "Comida";
        public const string Supermercado = "Supermercado";
        public const string Transporte = "Transporte";
        public static string Salud = "Salud";
        public static string Ocio = "Ocio";
        public static string Servicios = "Servicios";
        public static string Hogar = "Hogar";
        public static string Educacion = "Educación";
        public static string Ropa = "Ropa";
        public static string Otros = "Otros";

        public static readonly IReadOnlyList<string> Lista = new List<string>
    {
        Comida,
        Supermercado,
        Transporte,
        Salud,
        Ocio,
        Servicios,
        Hogar,
        Educacion,
        Ropa,
        Otros
    };

        public static string Normalizar(string? categoriaSugerida)
        {
            if (string.IsNullOrWhiteSpace(categoriaSugerida))
                return Otros;

            var coincidencia = Lista.FirstOrDefault(c =>
                c.Equals(categoriaSugerida.Trim(), StringComparison.OrdinalIgnoreCase));

            return coincidencia ?? Otros;
        }
    }
}