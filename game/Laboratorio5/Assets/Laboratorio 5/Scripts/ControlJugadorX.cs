 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugadorX : MonoBehaviour
{
    public bool gameOver;
    public GameObject jugador;
    public float fuerzaFlotar;
    private float modificadorGravedad = 1.5f;
    private Rigidbody jugadorRb;
    public int vida;
    public ParticleSystem particulaExplosion;
    public ParticleSystem particulaPirotecnia;
    public AudioClip sonidoMuerte;
    private GameManagerX gameManagerX;
    private AudioSource jugadorAudio;
    public AudioClip sonidoAtaque;
    public AudioClip sonidoExplision;
    public AudioClip sonido;
    public AudioClip sonido2;
    public Animator anim;
    public float speed;
    public float fuerzaSalto;
    private Vector3 targetAngles;
    public Collider[] colliders;
   private Rigidbody rb;
   public float coolDown = 1.5f;
   public  bool canShoot = true;
    public  bool canJump = true;

   //Start is called before the first frame update//
   void Start()
   {
    Debug.Log("Start");
       rb = GetComponent<Rigidbody>();
       //rb.isKinematic = true; 
       anim = gameObject.GetComponent<Animator>();
       anim = GetComponent<Animator>();
       jugadorAudio = GetComponent<AudioSource>();
        vida = 10;
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        jugadorAudio.PlayOneShot(sonido, 1.0f);
        gameManagerX.UpdateVidas(vida);
        fuerzaSalto = 7;
        
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
    public void audioChange(){
        jugadorAudio.Stop();
        jugadorAudio.PlayOneShot(sonido2,1.0f);
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
    transform.GetChild(0).gameObject.SetActive(false);
    if(transform.position.x>-1 && transform.position.x<23){
    if ((Input.GetKey(KeyCode.D))&& gameManagerX.esJuegoActivo && canJump){
        transform.position += new Vector3(4 * Time.deltaTime, 0, 0);
        anim.SetBool("movement", true);
        setVistaDer();
    }
    if ((Input.GetKey(KeyCode.A))&& gameManagerX.esJuegoActivo && canJump){
        transform.position += new Vector3(-4 * Time.deltaTime, 0, 0);
        anim.SetBool("movement", true);
        setVistaIz();
        //transform.localRotation *= Quaternion.Euler(0, 0, );
    }
    if ((Input.GetKey(KeyCode.W))&& gameManagerX.esJuegoActivo && canJump){
        //transform.position += new Vector3(0,  fuerzaSalto, 0);
        //rb.isKinematic = false; 
                    //jugadorRb.AddForce(Vector3.up * fuerzaFlotar);

        rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
        canJump = false;
        Invoke( "CooledDown2", 1.5f );
    }
    
    }else{
       
        if(transform.position.x>23){
            if (Input.GetKey(KeyCode.A) && gameManagerX.esJuegoActivo && canJump){
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D) && gameManagerX.esJuegoActivo && canJump){
                transform.position = new Vector3(0, 2.85f, 2);
            }
        }
       

        }
    if(transform.position.x<0){
        if (Input.GetKey(KeyCode.D) && gameManagerX.esJuegoActivo && canJump){
        transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
        } 
        if (Input.GetKey(KeyCode.A) && gameManagerX.esJuegoActivo && canJump){
                transform.position = new Vector3(22, 2.85f, 2);
            }
        }
    if (Input.GetKey(KeyCode.E)&& canShoot && gameManagerX.esJuegoActivo && canJump){
        //anim.SetBool("attack", true);
        anim.Play("fight");
        jugadorAudio.PlayOneShot(sonidoAtaque, 1.0f);
        transform.GetChild(0).gameObject.SetActive(true);
        canShoot = false;
        //transform.GetChild(0).gameObject.SetActive(false);
        Invoke( "CooledDown", 1.5f );
    }
    }
    
    
   void CooledDown()
 {
     
     canShoot = true;
     
 }
 void CooledDown2()
 {
    //rb.isKinematic = true; 

     canJump = true;
     //transform.position += new Vector3(0,  -fuerzaSalto, 0);
     
 }
   public void CollisionDetected(ChildScript childScript)
     {
         Debug.Log("child collided");
     } 

    private void OnCollisionEnter(Collision other)
    {
           // Debug.Log("OnCollisionEnter");
     // recibir dano
        if (other.gameObject.CompareTag("espadaE"))
        {
           // particulaExplosion.Play();
            //jugadorAudio.PlayOneShot(sonidoExplision, 1.0f);
            //vida = vida- 1;
            //Debug.Log(vida);
            vida = vida-1;
            gameManagerX.UpdateVidas(vida);
            if(vida<1){
                //GetComponent<Renderer>().enabled = false;
                gameManagerX.detener();
                anim.Play("death");
                jugadorAudio.PlayOneShot(sonidoMuerte, 2.0f);
                Destroy(gameObject,sonidoMuerte.length);
                gameManagerX.GameOver();
            }
            if (gameObject.transform.position.x > other.transform.position.x){
                gameObject.transform.position += new Vector3(140 * Time.deltaTime, 0, 0);
                
            }else{
                gameObject.transform.position += new Vector3(-140 * Time.deltaTime, 0, 0);
            }
         // We then get the opposite (-Vector3) and normalize it
         
         // And finally we add force in the direction of dir and multiply it by force.
         // This will push back the player
         
        }
         /* 
        // atacar enemigo
        if (other.gameObject.CompareTag("Bomba"))
        {
           // particulaExplosion.Play();
            //jugadorAudio.PlayOneShot(sonidoExplision, 1.0f);
            
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // si el jugador choca con dinero, pirotecnia
        else if (other.gameObject.CompareTag("Dinero"))
        {
            //particulaPirotecnia.Play();
            //jugadorAudio.PlayOneShot(sonidoDinero, 1.0f);
            Destroy(other.gameObject);

        }
       */  
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