using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContolGolpe : MonoBehaviour
{
    SegundoPersonaje segundoPersonaje;
    // Start is called before the first frame update
    void Start()
    {
        segundoPersonaje = GameObject.Find("megaman").GetComponent<SegundoPersonaje>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("tree"))
        {
            segundoPersonaje.SetContolArbol(collision.gameObject.GetComponent<ArbolController>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("tree"))
        {
            segundoPersonaje.SetContolArbol(null);
        }
    }
}
