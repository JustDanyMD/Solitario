using Solitario.Enumeraciones;



namespace Solitario.Entidades

{
    public class Fundacion : Pila
    {
        public Palo Palo {get; }

        public bool EstaCompleta => Cantidad == 13;

        public Fundacion(Palo palo )
        {
            Palo = palo;
        }
        
    }
}