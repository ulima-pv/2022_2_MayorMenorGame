
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Jugador
{
    public int Numero { get; set; }
    public bool EligioMayor { get; set; }
    public int Puntaje { get; set; }
    public bool RealizoSeleccion { get; set; }

    public Jugador(int num, bool eligioMayor)
    {
        Numero = num;
        EligioMayor = eligioMayor;
        Puntaje = 0;
        RealizoSeleccion = false;
    }

}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textoNumeroAleatorio;
    public Button butJugador1Mayor;
    public Button butJugador1Menor;
    public Button butJugador2Mayor;
    public Button butJugador2Menor;
    public Button butJugador3Mayor;
    public Button butJugador3Menor;

    private int mNumeroObtenido;
    private List<Jugador> mListaJugadores;

    private void Start()
    {
        Debug.Log("Se inicio el juego");

        mListaJugadores = new List<Jugador>();
        mListaJugadores.Add(new Jugador(1, false));
        mListaJugadores.Add(new Jugador(2, false));
        mListaJugadores.Add(new Jugador(3, false));

        System.Random rand = new System.Random();
        mNumeroObtenido = rand.Next(101);
        textoNumeroAleatorio.text = mNumeroObtenido.ToString();
    }

    public void BotonMostrarNumeroOnClick()
    {
        if (AnalizarSiJugadoresHicieronClick())
        {
            LimpiarSeleccionJugadores();
            // Obtener un numero aleatorio entre 0 y 100
            System.Random rand = new System.Random();
            var numeroAleatorio = rand.Next(101);

            // Poner numero aleatorio en el UI Text
            textoNumeroAleatorio.text = numeroAleatorio.ToString();

            // Comparar las elecciones de los jugadores
            CompararEleccionesJugadores(mNumeroObtenido, numeroAleatorio);

            mNumeroObtenido = numeroAleatorio;

            PintarPuntajesEnLog();
        }

    }

    private void PintarPuntajesEnLog()
    {
        foreach(var jugador in mListaJugadores)
        {
            Debug.Log($"Jugador:{jugador.Numero} Puntaje:{jugador.Puntaje}");
        }
    }

    private bool AnalizarSiJugadoresHicieronClick()
    {
        foreach (var jugador in mListaJugadores)
        {
            if (jugador.RealizoSeleccion == false) return false;
        }
        return true;
    }

    private void LimpiarSeleccionJugadores()
    {
        foreach(var jugador in mListaJugadores)
        {
            jugador.RealizoSeleccion = false;
        }
    }

    public void BotonMayorJugador1Onclick()
    {
        mListaJugadores[0].EligioMayor = true;
        mListaJugadores[0].RealizoSeleccion = true;
        var colors = butJugador1Mayor.colors;
        //colors.normalColor = Color.red;
        //colors.highlightedColor = Color.red;
        colors.selectedColor = Color.red;
        butJugador1Mayor.colors = colors;
    }

    public void BotonMenorJugador1OnClick()
    {
        mListaJugadores[0].EligioMayor = false;
        mListaJugadores[0].RealizoSeleccion = true;
    }

    public void BotonMayorJugador2Onclick()
    {
        mListaJugadores[1].EligioMayor = true;
        mListaJugadores[1].RealizoSeleccion = true;
    }

    public void BotonMenorJugador2OnClick()
    {
        mListaJugadores[1].EligioMayor = false;
        mListaJugadores[1].RealizoSeleccion = true;
    }

    public void BotonMayorJugador3Onclick()
    {
        mListaJugadores[2].EligioMayor = true;
        mListaJugadores[2].RealizoSeleccion = true;
    }

    public void BotonMenorJugador3OnClick()
    {
        mListaJugadores[2].EligioMayor = false;
        mListaJugadores[2].RealizoSeleccion = true;
    }

    private void CompararEleccionesJugadores(int numeroAnterior, int numeroNuevo)
    {
        bool esMayor = numeroNuevo > numeroAnterior;
        foreach (var jugador in mListaJugadores)
        {
            if (jugador.EligioMayor == esMayor)
            {
                jugador.Puntaje++;
            }
        }
    }
}
