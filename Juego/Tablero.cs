using Solitario.Entidades;
using Solitario.Enumeraciones;

public class Tablero
    {
        public Pila Mazo { get;}
        public Pila Descarte { get; }

        public List<Pila> Columnas{ get; }
        public List<Fundacion> Fundaciones { get;}

        public Tablero()
        {
            Mazo = new Pila();
            Descarte = new Pila();
            Columnas = new List<Pila>();
            Fundaciones = new List<Fundacion>();

            CrearColumnas();
            CrearFundaciones();
        }

        private void CrearColumnas()
        {
            for (int i = 0; i < 7; i++)
            {
                Columnas.Add(new Pila());
            }

        }

        private void CrearFundaciones()
        {
            foreach (Palo palo in Enum.GetValues<Palo>())
            {
               Fundaciones.Add(new Fundacion(palo)); 
            }
        }
    }
