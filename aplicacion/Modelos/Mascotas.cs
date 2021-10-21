using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
namespace Negocio.Modelos
{
    public class Mascota
    {
        public static NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        public string Nombre;
        public string Especie;
        public int IdPropietario;
        public override string ToString() => $"{Nombre}/{Especie}";
        public static Mascota ParseRow(string row)
        {           
            var columns = row.Split(',');
            return new Mascota
            {
                Nombre = columns[1].Trim(),
                Especie = columns[2].Trim(),
                IdPropietario = Int32.Parse(columns[0].Trim(), nfi)
            };
        }
    }
}