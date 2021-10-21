namespace UI
{
public class MascotaMV
    {
        public string Nombre;
        public string Especie;
        public string Propietario;
        public override string ToString(){
            return Nombre+" es el "+Especie+" de "+ Propietario;
        } 
    }
}