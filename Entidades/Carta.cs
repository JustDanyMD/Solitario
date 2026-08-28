using Solitario.Enumeraciones;

namespace Solitario.Entidades;
public class Carta 
{
    public Palo Palo { get;}
    public Valor Valor { get;}
    public bool EsRoja => Palo == Palo.Corazones || Palo == Palo.Diamantes;
    public bool EstaBocaAbajo { get; private set; }
    public Carta(Palo palo, Valor valor) 
    {
        Palo = palo;
        Valor = valor;
        EstaBocaAbajo = true;
    }

    public void Voltear() 
    {
        EstaBocaAbajo = !EstaBocaAbajo;
    }
    public override string ToString() 
    {
        if (EstaBocaAbajo)
            return "Carta boca abajo";
            
        return $"{Valor} de {Palo}";
    }
}