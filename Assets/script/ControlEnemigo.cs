using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlEnemigo : MonoBehaviour
{
    //SCRIPT PRIMER PERSONAJE
    public float vel = -1f;
    public Rigidbody2D rigidbody;
    Animator animator;
    //DECLARACION DE VARIABLES 

    public Slider slider;
    public Text text;
    public int energy;
    public GameObject bulletPrototype;

    //implementacion con audio
    AudioSource audio;
    public AudioClip disparo;
    public AudioClip ouch;
    public AudioClip dead;


    // Start is called before the first frame update
    void Start()
    {
        //INICIALIZACION 
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        energy = 100;
    }


    void Update()
    {
        if (energy <= 0)
        {
            energy = 1;
            animator.SetTrigger("morir");
            audio.PlayOneShot(dead);
            SceneManager.LoadScene("SampleScene");
        }
        slider.value = energy;
        text.text = energy.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MOVIEMIENTO Y CAMBIO DE UNA ANIMACION 
        Vector2 vector = new Vector2(vel, 0);
        rigidbody.velocity = vector;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Caminando") && Random.value < 1f / (60f * 3f)){

            animator.SetTrigger("apuntar");

        }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Apuntando")) {
            if (Random.value < 1f / 3f){
                animator.SetTrigger("disparar");
            }
            else
            {
                animator.SetTrigger("caminar");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Flip();
    }
    
    void Flip()
    {
        vel *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void Disparar()
    {
        animator.SetTrigger("apuntar");
    }

    public void EmitirBala()
    {
        audio.PlayOneShot(disparo);
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = transform.position;
        bulletCopy.GetComponent<ControlBala>().direccion = new Vector3(transform.localScale.x, 0, 0);
        energy--;
    }

    public void BajarPuntosPorOrcoCerca()
    {
        audio.PlayOneShot(ouch);
        energy-=40;
    }
}
