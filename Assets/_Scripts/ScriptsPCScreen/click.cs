using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public static bool enMouse { get; set; }



    private AudioSource avastSource;
    private AudioClip avastAudioclip;

    void Start()
    {
        this.avastSource = GameObject.Find("Sonido_avast").GetComponent<AudioSource>();
        this.avastAudioclip = avastSource.clip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //entra cuando el puntero este en colicion con otro objeto en este caso iconos
    private void OnTriggerStay(Collider icono)
    {
        //se mira que la mano se encuentra en colicion con el mouse y ademas que le dio click iquierdo
        if (Input.GetMouseButtonDown(0) == true && enMouse == true)
        {
            //se verifica si oprimio el icono de trabajo
            if (icono.gameObject.name.Equals("SprIcon_Job"))
            {
                if (job_bar.activo == false)
                {
                    cmd.activo = true;

                    //setea al job_bar.cs para que se muestre en el juego
                    job_bar.activo = true;
                    System.Random rnd = new System.Random();

                    job_bar.paga = Math.Round(rnd.NextDouble() * 10, 2);


                    //setea al cmd.cs para que se muestre en el juego y pueda empezar a programar
                }
                else
                {

                    if (job_bar.paga > 1.8 && job_bar.paga < 5.5)
                    {

                    }
                    else
                    {
                        System.Random rnd = new System.Random();
                        job_bar.paga = Math.Round(rnd.NextDouble() * 10, 2);
                    }
                }

            }
            if (icono.gameObject.name.Equals("SprIcon_Config"))
            {
                if (GameManager.dinero >= 5.9 && router.bug == true)
                {
                    GameManager.dinero = GameManager.dinero - 5.9;
                    router.bug = false;
                }
            }
            //se verifica si oprimio el icono de avast
            if (icono.gameObject.name.Equals("SprIcon_avast"))
            {
                GameManager.actualizoAvast = true;
                if (Virus.infectado == true)
                {
                    Virus.avast = true;

                }

                //se verifica que el sonido de avast no se esta reproduciendo
                // if (GameObject.Find("Sonido_avast").GetComponent<AudioSource>().isPlaying == false)
                // {
                //     //se reporduce el sonido del avast
                //     GameObject.Find("Sonido_avast").GetComponent<AudioSource>().Play();
                // }

                // lo mismo de arriba pero menos cutre
                if (this.avastSource.isPlaying == false)
                {
                    //se reporduce el sonido del avast
                    this.avastSource.PlayOneShot(this.avastAudioclip);
                }
            }
        }

    }

    private double GetRandomNumber(double v1, double v2)
    {
        throw new NotImplementedException();
    }
}
