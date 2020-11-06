using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigoController : MonoBehaviour
{

    Collider2D collidernenemigo = null;
    public int delayBajarPuntosEnemigo = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("enmigo") && collidernenemigo == null)
        {
            Debug.Log("Colision con el enemigo!");
            collidernenemigo = collision;
            Invoke("BajarPuntosEnemigo", delayBajarPuntosEnemigo);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision = collidernenemigo)
        {
            Debug.Log("Salir de colision con enemigo!!");
            collidernenemigo = null;
            CancelInvoke("BajarPuntosEnemigo");
        }
    }

    void BajarPuntosEnemigo()
    {
        Debug.Log("BajarPuntosEnemigo");
        collidernenemigo.gameObject.GetComponent<ControlEnemigo>().BajarPuntosPorOrcoCerca();
    }
}
