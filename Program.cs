using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] cities={"Tokyo", "London", "Rome", "Donlon", "Kyoto", "Paris", "otoky","mero", "sPaRi","Koyto","remo" };
        WriteLine( clasifiCities(cities));
    }
     public static string fMoverPal(string ciudad)
    {
        char[] SAnagrama = ciudad.ToCharArray();
        for (var i = 1; i < SAnagrama.Length; i++)
        {
            for (var j = 0; j < SAnagrama.Length - 1; j++)
            {
                if (SAnagrama[j] > SAnagrama[j + 1])
                {
                    var aux = SAnagrama[j];
                    SAnagrama[j] = SAnagrama[j + 1];
                    SAnagrama[j + 1] = aux;
                }
            }
        }
        var res = new string(SAnagrama);
        return res;
    }
    public static string clasifiCities(string[] saCities)
    {
        List<string> paramListCitys = saCities.ToList();
        // Donde he visto las Listas bidimensionales
        // https://www.it-swarm-es.com/es/c%23/lista-de-arrays-multidimensional-o-lista-en-c/968806650/
        List<List<string>> lBidiResulOrdenCities = new List<List<string>>();
        for (var i = 0; i < paramListCitys.Count; i++)
        {
            List<string> lPorVuelta = new List<string>();
            lPorVuelta.Add(paramListCitys[i]);
            for (var j = i + 1; j < paramListCitys.Count; j++)
            {
                if (fMoverPal(paramListCitys[i].ToUpper()) == fMoverPal(paramListCitys[j].ToUpper()))
                {
                    lPorVuelta.Add(paramListCitys[j]);
                    paramListCitys.RemoveAt(j);
                }
            }
            lBidiResulOrdenCities.Add(lPorVuelta);
        }
        return aBi_String(lBidiResulOrdenCities);
    }
    public static string aBi_String(List<List<string>> lista)
    {
        string resul="[";
        for (var i = 0; i < lista.Count; i++)
        {
            resul += (string.Join(", ", lista[i].ToArray()).ToString() + " ],[");
        }
        return resul.Substring(0,resul.Length-2);
    }
}
