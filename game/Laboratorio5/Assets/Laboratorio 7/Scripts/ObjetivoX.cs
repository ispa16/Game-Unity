using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManagerX gameManagerX;
    public int puntajeDeValor;
    public GameObject explosionFx;

    public float tiempoEnPantalla = 1.0f;

    private float minValorX = -3.75f; // the x value of the center of the left-most square
    private float minValorY = -3.75f; // the y value of the center of the bottom-most square
    private float espacioEntreCuadros = 2.5f; // the distance between the centers of squares on the game board
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = SpawnPosicionAleatoria(); 
        StartCoroutine(RemoverRutinaObjeto()); // begin timer before target leaves screen

    }

    // When target is clicked, destroy it, update score, and generate explosion
    private void OnMouseDown()
    {
        if (gameManagerX.esJuegoActivo)
        {
            Destroy(gameObject);
            gameManagerX.UpdateScore(puntajeDeValor);
            Explotar();
        }
               
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 SpawnPosicionAleatoria()
    {
        float spawnPosX = minValorX + (IndiceCuadroAleatorio() * espacioEntreCuadros);
        float spawnPosY = minValorY + (IndiceCuadroAleatorio() * espacioEntreCuadros);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int IndiceCuadroAleatorio ()
    {
        return Random.Range(0, 4);
    }


    // If target that is NOT the bad object collides with sensor, trigger game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            gameManagerX.GameOver();
        } 

    }

    // Display explosion particle at object's position
    void Explotar ()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }

    // After a delay, Moves the object behind background so it collides with the Sensor object
    IEnumerator RemoverRutinaObjeto ()
    {
        yield return new WaitForSeconds(tiempoEnPantalla);
        if (gameManagerX.esJuegoActivo)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }

    }

}
