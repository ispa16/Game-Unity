using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe1 : MonoBehaviour
{
     public int vida;
    public GameObject jefe1f;
    public float fuerzaFlotar;
    private float modificadorGravedad = 1.5f;
    private Rigidbody jugadorRb;
    
    public ParticleSystem particulaExplosion;
    public ParticleSystem particulaPirotecnia;
    private GameManagerX gameManagerX;
    private AudioSource jugadorAudio;
    public AudioClip sonidoAtaque;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoDescubrir;
    public AudioClip sonidoExplision;
    public GameObject camara;
    public Animator anim;
    private Vector3 targetAngles;
    public Collider[] colliders;
   private Rigidbody rb;
    private float speed = 1.0f;
    private GameObject jugador;
 private Vector3 jugadorPos;
 public float coolDown = 3.5f;
   public  bool canShoot = true;
   public  bool canShout = true;
   public bool alive;
   //Start is called before the first frame update//
   void Start()
   {
    Debug.Log("Start");
       rb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
       anim = gameObject.GetComponent<Animator>();
       anim = GetComponent<Animator>();
        vida = 5;   
           jugadorAudio = GetComponent<AudioSource>();

        jugador = GameObject.Find("Jugador");
        alive = true;
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
    //que siga al jugador
    anim.SetBool("walk", false);
    transform.GetChild(0).gameObject.SetActive(false);
    
    if(((transform.position.x -jugador.transform.position.x)<4) && ((transform.position.x -jugador.transform.position.x)>-4) && (canShoot == true) && alive){
            anim.Play("fight");
            Debug.Log(canShoot);
            transform.GetChild(0).gameObject.SetActive(true);
            canShoot = false;
            jugadorAudio.PlayOneShot(sonidoAtaque, 1.0f);

            Invoke("CooledDown", 3.0f);
        }
    if((transform.position.x -jugador.transform.position.x)<10 && alive && (transform.position.x -jugador.transform.position.x)>-10 ){
        if(canShout){
            jugadorAudio.PlayOneShot(sonidoDescubrir, 1.0f);
            canShout= false;
            Invoke("CooledDown2", 15.0f);
        }
        
        
    }
    if((transform.position.x -jugador.transform.position.x)<800 && alive && (transform.position.x -jugador.transform.position.x)>-800 && gameManagerX.esJuegoActivo){
        if(gameObject.transform.position.x > jugador.transform.position.x ){
                    
                    setVistaIz();
                    jugadorPos = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, jugadorPos, speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                }else{
                    setVistaDer();
                    jugadorPos = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, jugadorPos, speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                }
    }
    
   }
   void CooledDown()
 {
     Debug.Log("canShoot = true");
     canShoot = true;
     
 }
 void CooledDown2()
 {
     canShout = true;
     
 }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("OnCollisionEnter");

        // recibir dano
        if (other.gameObject.CompareTag("espadaj"))
        {
           // particulaExplosion.Play();
            //jugadorAudio.PlayOneShot(sonidoExplision, 1.0f);
            vida = vida- 1;
            if(vida<1){
                //GetComponent<Renderer>().enabled = false;
                //gameObject.GetComponent<Animator>().enabled = false;
                particulaExplosion.Play();
                alive = false;
                anim.Play("death");
                jugadorAudio.PlayOneShot(sonidoMuerte, 2.0f);
                gameManagerX.UpdateScore(100);
                particulaExplosion.Play();
                gameManagerX.Victory();
                Destroy(gameObject,sonidoMuerte.length);
            }
            Debug.Log(vida);
            if (gameObject.transform.position.x > other.transform.position.x){
                gameObject.transform.position += new Vector3(90 * Time.deltaTime, 0, 0);
            }else{
                gameObject.transform.position += new Vector3(-90 * Time.deltaTime, 0, 0);
            }
         // We then get the opposite (-Vector3) and normalize it
         
         // And finally we add force in the direction of dir and multiply it by force.
         // This will push back the player
         
        } 

        // si el jugador choca con dinero, pirotecnia
        
       
    }
}
