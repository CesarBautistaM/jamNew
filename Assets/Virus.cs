using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Virus : MonoBehaviour
{
    public static bool avast { get; set; }
    public static bool infectado { get; set; }
    private bool informado;

    private AudioSource tempAudioSource;
    private AudioClip tempAudioclip;

    void Start()
    {
        infectado = false;
        avast = false;

        this.tempAudioSource = this.GetComponent<AudioSource>();
        this.tempAudioclip = tempAudioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {

        if (infectado == true && avast == false)
        {
            if (informado == false)
            {
                informado = true;

                // play the keyboard sound
                tempAudioSource.PlayOneShot(tempAudioclip);





                if (job_bar.activo == true)
                {
                    if ((job_bar.trabajo + 25) <= 100)
                    {
                        job_bar.trabajo = job_bar.trabajo + 25;
                    }
                    else
                    {
                        job_bar.trabajo = 100;
                    }
                }
            }
            if (job_bar.activo == true)
            {
                if ((job_bar.trabajo + 0.1f) <= 100)
                {
                    job_bar.trabajo = job_bar.trabajo + 0.1f;
                }

            }
        }
        else
        {
            infectado = false;
            avast = false;
        }
    }
}
