using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SegundoPersonaje : MonoBehaviour
{
    //SCRIPT DE SEGUNDO PERSONAJE
    public Rigidbody2D rigidbody=null;
    Animator animator;
    public int maxVel=5;
    bool haciaDerecha = true;

    public Slider slider;
    public Text text;
    public float energy;
    public bool disparo = false;

    public int pemioArbol = 15;

    public int constpGolpeAire = 1;
    public int costoGolpeArbol = 3;

    public ArbolController arbolController=null;

    public bool jumpuing = false;
    public float yJumpForce = 300;
    Vector2 jumpForce;

    public int costoBala = 20;
    public bool isOnTheFloor;

    //implementacion de auido
    AudioSource audio;

    public AudioClip cortandoArbol;
    public AudioClip ouch;
    public AudioClip dead;
    

    // Start is called before the first frame update
    void Start()
    {
        energy = 100;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        jumpForce = new Vector2(0, 0);

    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            if (energy <= 0)
            {
                energy = 0;
                animator.SetTrigger("dead");
                audio.PlayOneShot(dead);
                SceneManager.LoadScene("SampleScene");
            }
 
        }
        else
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F)){
            if (disparo==false){
                disparo = true;
                animator.SetTrigger("shoot");
                if (arbolController != null){
                    if (arbolController.DisparoMegaman())
                    {
                        energy += pemioArbol;
                        if (energy > 100)
                        {
                            energy = 100;
                        }
                    }
                    else
                    {
                        energy -= costoGolpeArbol;
                        audio.PlayOneShot(cortandoArbol);
                    }
                }
                else
                {
                    energy -= constpGolpeAire;
                }
            }else{
                disparo = false;
            }
        } 
        slider.value = energy;
        text.text = energy.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vel=Input.GetAxis("Horizontal");
        Vector2 vector = new Vector2(0, rigidbody.velocity.y);
        vel *= maxVel;
        vector.x = vel;
        rigidbody.velocity = vector;
        animator.SetFloat("velocidad", vector.x);
        if (haciaDerecha&&vel<0){
            haciaDerecha = false;
            Flip();
        }
        else if(!haciaDerecha&&vel>0){
            haciaDerecha = true;
            Flip();
        }
        VerificarInputParaSaltar();

    }

    private void VerificarInputParaSaltar()
    {
        isOnTheFloor = rigidbody.velocity.x == 0;

        if (Input.GetAxis("Jump") > 0.1f)
        {
            if (!jumpuing&&isOnTheFloor)
            {
                jumpuing = true;
                animator.SetTrigger("jump");
                jumpForce.x = 0f;
                jumpForce.y = yJumpForce;
                rigidbody.AddForce(jumpForce);
            }
        }
        else
        {
            jumpuing = false;
        }
    }

    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void SetContolArbol(ArbolController arbolController)
    {
        this.arbolController = arbolController;
    }

    public void RecibirBala()
    {
        audio.PlayOneShot(ouch);
        energy -= costoBala;
    }
       
}
