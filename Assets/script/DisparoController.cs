using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{

    Collider2D disparandoA = null;
    public float probalidadDeDisaparo = 1f;
    ControlEnemigo controlEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        controlEnemigo = GameObject.Find("enmigo").GetComponent<ControlEnemigo>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("tree")&&disparandoA == null)
        {
            DecidaSiDisparo(collision);
        }
        if (collision.gameObject.name.Equals("megaman") && disparandoA == null)
        {
            Discpara();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision = disparandoA)
        {
            disparandoA = null;
        }
    }

    void DecidaSiDisparo(Collider2D collision)
    {
        if (Random.value < probalidadDeDisaparo)
        {
            Discpara();
            disparandoA = collision;
        }
    }

    void Discpara()
    {
        controlEnemigo.Disparar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
