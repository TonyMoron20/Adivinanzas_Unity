using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string[] adivinanzas = { "Su cabeza es amarilla, siguiendo al sol, gira y gira, muchos comen sus pepitas y dicen que son muy ricas.",
        "Tengo agujas pero no sé coser, tengo números pero no sé leer, las horas te doy, ¿sabes quién soy?",
        "¿Qué cosa es, qué cosa es, que corre mucho y no tiene pies?" };

    private string[] respuestas = { "girasol", "reloj", "viento" };

    private int navegacion = 0;
    string respuestaUsuario;
    public Text textoPregunta, respuestaPregunta, textofinal;
    public GameObject panelDeInicio, panelDeFinal, background;
    private int puntos = 0, vida = 3;

    // Start is called before the first frame update
    void Start()
    {
        panelDeInicio.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        MostrarPregunta();
        GuardaRespuestaUsuario();
        GameOver();
    }

    void MostrarPregunta()
    {
        textoPregunta.text = adivinanzas[navegacion];
    }

    void GuardaRespuestaUsuario()
    {
        if(respuestaPregunta.text != "")
        {
            respuestaUsuario = respuestaPregunta.text;
            //Debug.Log(respuestaUsuario);
        }
    }

    public void ValidacionRespuesta()
    {
        string respuestaCorrecta = respuestas[navegacion].ToUpper();
        string respuestaActualUsuario = respuestaUsuario.ToUpper();

        if(respuestaCorrecta == respuestaActualUsuario)
        {
            puntos++;
            Debug.Log("Correcto");
            SiguienteAdivinanza();
        }
        else
        {
            Debug.Log("Incorrecto");
            vida--;
        }
    }

    public void SiguienteAdivinanza()
    {
        if(navegacion + 1 > adivinanzas.Length - 1)
        {
            navegacion = 0;
            panelDeFinal.SetActive(true);
            PantallaFinal();
        }
        else
        {
            navegacion++;
        }
    }

    public void IniciarJuego()
    {
        if(panelDeInicio.activeInHierarchy == true)
        {
            panelDeInicio.SetActive(false);
        }

        if(panelDeFinal.activeInHierarchy == true)
        {
            panelDeFinal.SetActive(false);
        }
    }

    public void PantallaFinal()
    {
        if(puntos > 2)
        {
            textofinal.text = "GANASTE!";
        } 
        else if(vida == 0 || puntos < 2)
        {
            textofinal.text = "PERDISTE!";
        }
    }

    private void GameOver()
    {
        if(vida == 0)
        {
            panelDeFinal.SetActive(true);
            PantallaFinal();
        }
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
