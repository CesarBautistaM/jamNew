using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teclado2 : MonoBehaviour
{
    private Animator anim;
    public static int nivel { set; get; }
    public static bool limpiador { set; get; }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetInteger("Lvl_Suciedad", nivel);
        anim.SetBool("Limpiador", limpiador);
        if (limpiador == true)
        {
            nivel = 0;
            limpiador = false;
        }

    }
}
