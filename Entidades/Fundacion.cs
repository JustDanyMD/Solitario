using Solitario.Enumeraciones;



namespace Solitario.Entidades

{
    public class Fundacion : Pila
    {
        public Palo Palo {get; }

        public Fundacion(Palo palo )
        {
            Palo = palo;
        }
        
    }
}