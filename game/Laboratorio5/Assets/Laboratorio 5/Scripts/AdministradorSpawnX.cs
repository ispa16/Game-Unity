using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorSpawnX : MonoBehaviour
{/*
    public GameObject[] objetosPrefabs;
    private float spawnRetraso = 2;
    private float spawnIntervalo = 1.5f;

    private ControlJugadorX controlJugadorScript;
    
    void Start()
    {
        InvokeRepeating("SpawnObjectos", spawnRetraso, spawnIntervalo);
        controlJugadorScript = GameObject.Find("Jugador").GetComponent<ControlJugadorX>();
    }

    // Spawn obstaculos
    void SpawnObjectos ()
    {
        // Establecer la ubicación de generación aleatoria y el índice de objetos aleatorios
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objetosPrefabs.Length);

        // Si el juego aún está activo, genera un nuevo objeto
        if (!controlJugadorScript.gameOver)
        {
            objetosPrefabs[index].SetActive(true);
            Instantiate(objetosPrefabs[index], spawnLocation, objetosPrefabs[index].transform.rotation);
        }

    }*/
}
