using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Negocio.Modelos
{

public class Propietario
{
    public static NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
    public int IdPropietario;
    public string Nombre;
    public char Sexo = 'M';

    public override string ToString() => $"{Sexo} {Nombre}===> {IdPropietario}";

    internal static Propietario ParseRow(string row)
        {   
            var columns = row.Split(',');
            return new Propietario
            {
                Nombre = columns[1].Trim(),
                Sexo = columns[2].Trim()[0],
                IdPropietario = Int32.Parse(columns[0].Trim(), nfi)
            };
        }
}
}