using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
public class follow : MonoBehaviour
{
    public int puntuacion;
    public Transform player;
    Transform CamTransform;

    // Update is called once per frame
    void Start(){
        puntuacion = 0;
        CamTransform = Camera.main.transform;
    }
    void Update () {
        CamTransform.position = new Vector3(player.position.x, CamTransform.position.y,  CamTransform.position.z);
        //transform.position = player.transform.position + new Vector3(3, 5, -16);
        //Debug.Log(puntuacion);
    }
}
    

