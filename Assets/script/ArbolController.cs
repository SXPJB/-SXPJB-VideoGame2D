using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolController : MonoBehaviour
{
    public int contGolpesParaCaer = 3;
    public int numBalasParaCaer = 3;
    Animator animator = null;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DisparoMegaman()
    {
        bool resp = false;
        contGolpesParaCaer--;
        if (contGolpesParaCaer <= 0)
        {
            animator.SetTrigger("caer");
            resp = true;
        }
        return resp;
    }

    public bool RecibirDisparo()
    {
        bool resp = false;
        numBalasParaCaer--;
        switch (numBalasParaCaer)
        {
            case 2:
                renderer.color = new Color(1f / 242, 1f / 155, 1f / 155, 1f);
                break;
            case 1:
                renderer.color = new Color(1f / 216, 1f / 10, 1f / 10);
                break;
        }
        if (numBalasParaCaer <= 0)
        {
            animator.SetTrigger("caer");
            resp = true;
        }

        return resp;
    }

}
