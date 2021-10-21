using System;
using System.Collections.Generic;
using System.Linq;
using Servicios;
namespace Negocio
{
    using Negocio.Modelos;
    public class GestorDeMascotas
    {
        IRepositorio Repositorio;
        List<Propietario> cachePropietarios = new List<Propietario>{};
        List<Mascota> cacheMascotas = new List<Mascota>{};
        public GestorDeMascotas(IRepositorio repositorio)
        {
            Repositorio = repositorio;
            Repositorio.Inicializar();
            cachePropietarios = Repositorio.CargarPropietarios();
            cacheMascotas = Repositorio.CargarMascotas();
        }
        public List<Propietario> ObtenerPropietarios() => cachePropietarios;
        public List<Mascota> ObtenerMascotas() => cacheMascotas;
    }
}