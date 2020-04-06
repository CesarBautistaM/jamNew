using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public static bool enMouse { get; set; }
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //entra cuando el puntero este en colicion con otro objeto en este caso iconos
    private void OnTriggerStay(Collider icono)
    {
        //se mira que la mano se encuentra en colicion con el mouse y ademas que le dio click iquierdo
        if(Input.GetMouseButtonDown(0)==true && enMouse == true)
        {
            //se verifica si oprimio el icono de trabajo
            if (icono.gameObject.name.Equals("SprIcon_Job"))
            {
                //setea al job_bar.cs para que se muestre en el juego
                job_bar.activo = true;
                //setea al cmd.cs para que se muestre en el juego y pueda empezar a programar
                cmd.activo = true;

            }
            //se verifica si oprimio el icono de avast
            if (icono.gameObject.name.Equals("SprIcon_avast"))
            {
                //se verifica que el sonido de avast no se esta reproduciendo
                if (GameObject.Find("Sonido_avast").GetComponent<AudioSource>().isPlaying == false)
                {
                    //se reporduce el sonido del avast
                    GameObject.Find("Sonido_avast").GetComponent<AudioSource>().Play();
                }
            }
        }
        
    }
}
