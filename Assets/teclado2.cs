using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teclado2 : MonoBehaviour
{
    private Animator anim;
    public static int nivel { set; get; }
    public static bool limpiador { set; get; }
    private int teclas;
    void Start()
    {
        teclas = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        job_bar.bug = nivel / 100;
        if (Input.anyKeyDown == true)
        {
            if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
            {
                teclas++;
            }
        }
        if (teclas > 900)
        {
            nivel++;
            teclas = 0;
        }
        anim.SetInteger("Lvl_Suciedad", nivel);
        anim.SetBool("Limpiador", limpiador);
        if (limpiador == true)
        {
            nivel = 0;
            limpiador = false;
        }

    }
}
