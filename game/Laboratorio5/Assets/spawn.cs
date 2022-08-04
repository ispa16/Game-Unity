using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject jefePrefab;

    //private float spawnRangoX = 35;
    private float spawnZMin = 2; // set min spawn Z
    private float spawnZMax = 35; // set max spawn Z

    public int conteoEnemigos;
    public int conteoOlas = 1;
    public int velocidaden =30;
    private GameManagerX gameManagerX;

    public GameObject player; 

    // Update se llama una vez por frame
    void Start(){
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        gameManagerX.UpdateOla(1);
        Debug.Log("transform.position.x");
    }
    void Update()
    {
        conteoEnemigos = GameObject.FindGameObjectsWithTag("Bomba").Length;

        if (conteoEnemigos == 0)
        {
            SpawnOlaEnemiga(conteoOlas);
        }

    }

    // Genera una posición spawn aleatoria para powerups y bolas enemigas
    Vector3 GeneradorPosicionSpawn ()
    {
        float xPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 2.85f, 2);
    }


    void SpawnOlaEnemiga(int enemigoParaSpawn)
    {

        // Si no quedan powerups, generar un powerup
        gameManagerX.UpdateOla(conteoOlas);

        // Generar número de bolas enemigas según el número de ola
        if (conteoOlas == 5){
            GameObject obj = (GameObject)Instantiate(jefePrefab, GeneradorPosicionSpawn(), jefePrefab.transform.rotation);
            obj.SetActive(true);
        }
        for (int i = 0; i < conteoOlas; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemigoPrefab, GeneradorPosicionSpawn(), enemigoPrefab.transform.rotation);
            obj.SetActive(true);
            //Instantiate(enemigoPrefab, GeneradorPosicionSpawn(), enemigoPrefab.transform.rotation);
            //enemigoPrefab
            
        }
        //dar velocidad por ola
        conteoOlas++;
        //gameManagerX.UpdateOla(conteoOlas);

        ResetPlayerPosition(); // volver a poner al jugador al inicio

    }

    // Mueve al jugador de vuelta a la posición delante de la propia meta
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(2, 2.85f, 2);


    }

}
