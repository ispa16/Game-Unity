using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultadBotonX : MonoBehaviour
{
    private Button boton;
    private GameManagerX gameManagerX;
    public int dificultad;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        boton = GetComponent<Button>();
        boton.onClick.AddListener(SetDifficulty);
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void SetDifficulty()
    {
        Debug.Log(boton.gameObject.name + " fue seleccionado");
        gameManagerX.ComenzarJuego(dificultad);

    }



}
