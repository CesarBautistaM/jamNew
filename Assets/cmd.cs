using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd : MonoBehaviour
{
    private Animator anim;
    public static bool activo { get; set; }
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        //se oculta la consola de cmd
        GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //se setea la animacion con activo para que si esta activo miuestre la animacion
        anim.SetBool("trabajando", activo);
        //se oculta o se muestra con referencia si esta activo o no
        GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = activo;
        //en el caso que este activo
        if (activo == true)
        {
            //y oprima una tecla excepto del mouse
            if (Input.anyKeyDown == true)
            {
                if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
                {
                    //reproduce la animacion de programacion
                    anim.speed = 2;
                }
            }
            
            else
            {
                //si no pausa la animacion
                anim.speed = 0;

            }
        }
    }
}
