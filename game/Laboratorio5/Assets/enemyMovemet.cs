 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public int vida;
    public GameObject enemigo;
    public float fuerzaFlotar;
    private float modificadorGravedad = 1.5f;
    private Rigidbody jugadorRb;
    
    public ParticleSystem particulaExplosion;
    public ParticleSystem particulaPirotecnia;

    private AudioSource jugadorAudio;
    public AudioClip sonidoDinero;
    public AudioClip sonidoExplision;
    
    public Animator anim;
    public float speed;
    private Vector3 targetAngles;
    public Collider[] colliders;
   private Rigidbody rb;
   
   
   //Start is called before the first frame update//
   void Start()
   {
    Debug.Log("Start");
       rb = GetComponent<Rigidbody>();
       anim = gameObject.GetComponent<Animator>();
       anim = GetComponent<Animator>();
    vida = 3;   
    
   }
   
   //Update is called once per frame
   //rotar
   private static Quaternion Change(float x, float y, float z)
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(x, y, z, 1);
        //Return the new Quaternion
        return newQuaternion;
    }
   void setVistaDer(){
     transform.rotation = Change(0, 0, 0);
   }
   void setVistaIz(){
     transform.rotation = Change(0,-180,0);
   }
   void FixedUpdate()
   {
    //que no se salga del limite inferior
    
    anim.SetBool("movement", false);
    //anim.SetBool("attack", false);
    //transform.GetChild(0).gameObject.SetActive(false);
    if(vida<1){
        Destroy(gameObject);
    }
    if(transform.position.x>-10){
   
    }else{
       if ((Input.GetKey(KeyCode.D))){
        
    } 
    
    }
    
   }


   public void CollisionDetected(ChildScript childScript)
     {
         Debug.Log("enemy collided");
     } 

    private void OnCollisionEnter(Collision other)
    {
           // Debug.Log("OnCollisionEnter");

        // atacar enemigo
        if (other.gameObject.CompareTag("espadaj"))
        {
           // particulaExplosion.Play();
            //jugadorAudio.PlayOneShot(sonidoExplision, 1.0f);
            vida = vida- 1;
            Debug.Log(vida);
        } 

        // si el jugador choca con dinero, pirotecnia
        else if (other.gameObject.CompareTag("Dinero"))
        {
            //particulaPirotecnia.Play();
            //jugadorAudio.PlayOneShot(sonidoDinero, 1.0f);
            Destroy(other.gameObject);

        }
       
    }
 
/*

    // Start es llamado antes de la actualización del primer frame.
    void Start()
    {
        jugadorRb= GetComponent<Rigidbody>();
        Physics.gravity *= modificadorGravedad;
        jugadorAudio = GetComponent<AudioSource>();
        
        // Aplique una pequeña fuerza hacia arriba al comienzo del juego.
        jugadorRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        
    }

    // Update se llama una vez por frame
    void Update()
    {
        var posicion = GameObject.Find("Jugador").transform.position.y;
        // Mientras se presiona el espacio y el jugador está lo suficientemente bajo, flota hacia arriba
        if (Input.GetKey(KeyCode.Space) && !gameOver && posicion <14 )
        {   
            jugadorRb.AddForce(Vector3.up * fuerzaFlotar);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Si el jugador choca con una bomba, explota y establece gameOver a true
        if (other.gameObject.CompareTag("Bomba"))
        {
            particulaExplosion.Play();
            jugadorAudio.PlayOneShot(sonidoExplision, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // si el jugador choca con dinero, pirotecnia
        else if (other.gameObject.CompareTag("Dinero"))
        {
            particulaPirotecnia.Play();
            jugadorAudio.PlayOneShot(sonidoDinero, 1.0f);
            Destroy(other.gameObject);

        }
         else if (GameObject.Find("Suelo"))
        {   
            jugadorRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }*/

}