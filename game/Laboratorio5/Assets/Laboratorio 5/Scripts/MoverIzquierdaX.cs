using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverIzquierdaX : MonoBehaviour
{
    public float velocidad;
    private ControlJugadorX controlJugadorScript;
    private float limiteIzquierda = -10;
    
    void Start()
    {
        //controlJugadorScript = GameObject.Find("Jugador").GetComponent<ControlJugadorX>();
    }
    
    void Update()
    {
        

    }
}