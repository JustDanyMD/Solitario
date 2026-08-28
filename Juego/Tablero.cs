using Solitario.Entidades;
public class Tablero
    {
        public Pila Mazo { get;}
        public Pila Descarte { get; }

        public List<Pila> Columnas{ get; }
        public List<Pila> Fundaciones { get;}

        public Tablero()
        {
            Mazo = new Pila();
            Descarte = new Pila();
            Columnas = new List<Pila>();
            Fundaciones = new List<Pila>();

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
            for (int i = 0; i < 4; i++)
            {
                Fundaciones.Add(new Pila());
            }
        }
    }
