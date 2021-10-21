using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
namespace UI.Consola
{
    using System;
    using Negocio;
    using Negocio.Modelos;
    using UI;
    public class Controlador
    {
        private GestorDeMascotas sistema;
        private Vista vista;
        private Dictionary<string, Action> casosDeUso;
        public Controlador(GestorDeMascotas sistema, Vista vista)
        {
            this.sistema = sistema;
            this.vista = vista;
            this.casosDeUso = new Dictionary<string, Action>(){
                { "Registrar una mascota", RegistrarMascota },
                { "Listar perros con dueño chicos", PerrosConDueñoH },
            };
        }
        public void Run()
        {
        try
        {
            while (true)
            {
                var key=vista.TrySeleccionarOpcionDeListaEnumerada<string>(
                    "\nGestor de mascotas\n", 
                    casosDeUso.Keys.ToList(),
                    "Selecciona una opcion"
                );
                casosDeUso[key].Invoke();
            }
        }
        catch
        {
            vista.Display("Agur usuario");
        }
    }
        void RegistrarMascota()
        {
            try
            {
                var propietario = vista.TrySeleccionarOpcionDeListaEnumerada("Listado de propietarios de mascotas\nSexo, Nombre, Id", sistema.ObtenerPropietarios(), "Indica el id de un comprador");
                var nombre = vista.TryObtenerEntradaDeTipo<string>("Nombre de la mascota?");
                var especie = vista.TryObtenerEntradaDeTipo<string>("Especie");
                //var hecho = sistema.ComprarMascota(propietario, new Mascota { Nombre = nombre, Especie = especie });
                try
                {
                    //Fuente: https://www.iteramos.com/pregunta/29044/como-anadir-una-nueva-linea-en-un-archivo-txt
                    TextWriter sw = new StreamWriter("Data/mascotas.csv", true);
                    sw.WriteLine(propietario.IdPropietario+", "+nombre+", "+especie);
                    sw.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        void PerrosConDueñoH()
        {
            var propietarios = sistema.ObtenerPropietarios();
            var mascotas = sistema.ObtenerMascotas();
            // De donde he pillado como hacer las querys => https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq
            var query = from dueño in propietarios join mascota in mascotas on dueño.IdPropietario equals mascota.IdPropietario where dueño.Sexo == 'H' & mascota.Especie == "perro" select new MascotaMV { Propietario = dueño.Nombre, Nombre = mascota.Nombre, Especie = mascota.Especie };
            vista.MostrarListaEnumerada("Perros cuyo propietario es hombre", query.ToList());
        }        
    }
}