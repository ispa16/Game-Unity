using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirAmbienteX : MonoBehaviour
{
    private Vector3 inicialPos;
    private float repetirAncho;

    private void Start()
    {
        inicialPos = transform.position; // Establecer la posición inicial predeterminada
        repetirAncho = GetComponent<BoxCollider>().size.x / 2; // Establezca el ancho de repetición en la mitad del fondo
    }

    private void Update()
    {
        // Si el fondo se mueve a la izquierda por su ancho de repetición, muévalo de nuevo a la posición inicial
        //Debug.Log(transform.position.x);
        //Debug.Log(inicialPos.x - repetirAncho);
        if (transform.position.x < inicialPos.x - repetirAncho)
        {
            transform.position = inicialPos;
            
        }
    }

 
}


