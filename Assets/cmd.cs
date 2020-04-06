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
        GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("trabajando", activo);
        GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = activo;
        if (activo == true)
        {
            if (Input.anyKeyDown == true)
            {
                if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
                {
                    anim.speed = 2;
                }
            }
            else
            {
                anim.speed = 0;
            }
        }
    }
}
