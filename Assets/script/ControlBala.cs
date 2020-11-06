using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{

    public float speed = 6;
    public float lifeTime = 2;
    public Vector3 direccion = new Vector3(-1, 0 , 0);

    Vector3 stepVector;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rigidbody = GetComponent<Rigidbody2D>();
        stepVector = speed * direccion.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rigidbody.velocity = stepVector;   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("tree"))
        {
            ArbolController arbolController = collision.gameObject.GetComponent<ArbolController>();
            if (arbolController != null)
            {
                arbolController.RecibirDisparo();
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Equals("megaman"))
        {
            SegundoPersonaje controller = collision.gameObject.GetComponent<SegundoPersonaje>();
            if (controller != null)
            {
                controller.RecibirBala();
                Destroy(gameObject);
            }
        }
    }
}
