using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI puntajeTexto;
    public TextMeshProUGUI gameOverTexto;
    public TextMeshProUGUI tiempoTexto;
    public TextMeshProUGUI vidaTexto;
    public TextMeshProUGUI victorytxt;
    public TextMeshProUGUI olaPant;
    public TextMeshProUGUI olatxt;

    public GameObject pantallaPrincipal;
    public Button reiniciarBoton; 
    public GameObject jugador;
    private AudioSource managerAudio;
    public AudioClip Final;
    public AudioClip FinalV;
    private int puntaje;
    public int vida;
    public int ola;
    private float spawnIntervalo = 1.5f;
    private float tempo = 120.0f;
    public bool esJuegoActivo;

    private float espacioEntreCuadros = 2.5f; 
    private float minValorX = -3.75f; //  valor x del centro del cuadrado de la izquierda
    private float minValorY = -3.75f; //  valor y del centro del cuadrado de la parte inferior

    // Inicie el juego, elimine la pantalla de título, reinicie la puntuación y
    // ajuste el intervalo de generación en función del botón de dificultad en el que se hizo clic.
    public void ComenzarJuego(int value)
    {
        var ddjugador = GameObject.Find("Jugador").GetComponent<ControlJugadorX>();
        ddjugador.audioChange();
        spawnIntervalo /= value;
        esJuegoActivo = true;
        puntaje = 0;
        ola = 0;
        UpdateScore(0);
        
        pantallaPrincipal.SetActive(false);
        managerAudio = GetComponent<AudioSource>();
    }

    // Mientras el juego está activo genera un objetivo aleatorio


    void Update(){
        if(esJuegoActivo){
            CuentaRegresiva();
        }
    }
    void CuentaRegresiva(){
        tempo -= Time.deltaTime;
        tiempoTexto.text = "Tiempo: "+ Mathf.Round(tempo);
        if (tempo < 0){
            //esJuegoActivo = false;
            GameOver();
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValorX + (RandomSquareIndex() * espacioEntreCuadros);
        float spawnPosY = minValorY + (RandomSquareIndex() * espacioEntreCuadros);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        puntaje += scoreToAdd;
        puntajeTexto.text = "Puntaje: " + puntaje;
    }
    public void UpdateVidas(int vida)
    {
        vidaTexto.text = "Vidas: " + vida;
    }
    public void UpdateOla(int olaf)
    {
        olatxt.text = "Número de ola: " + olaf;
        if(olaf != 1){
            updatePant(olaf);
        }
    }
    void updatePant(int olaf){
        olaPant.text = "OLEADA #"+ olaf;
        olaPant.gameObject.SetActive( true ); 
        Invoke("DisableText", 5f);//invoke after 5 seconds
    }
    // Stop game, bring up game over text and restart button
   void DisableText()
   { 
      olaPant.gameObject.SetActive( false );
   }    
    public void GameOver()
    {
        gameOverTexto.gameObject.SetActive(true);
        reiniciarBoton.gameObject.SetActive(true);
        esJuegoActivo = false;
        managerAudio.PlayOneShot(Final, 1.0f);
    }

    public void Victory()
    {
        puntajeTexto.text = "puntaje: " + puntaje;
        victorytxt.gameObject.SetActive(true);
        reiniciarBoton.gameObject.SetActive(true);
        esJuegoActivo = false;
        managerAudio.PlayOneShot(FinalV, 1.0f);
    }
    public void detener()
    {
        esJuegoActivo = false;
    }
    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        tempo=60.0f;
    }

}
