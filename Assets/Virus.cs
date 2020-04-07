using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Virus : MonoBehaviour
{
    public static bool avast { get; set; }
    public static bool infectado { get; set; }
    private bool informado;

    void Start()
    {
        infectado = false;
        avast = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (infectado == true && avast == false)
        {
            if (informado == false)
            {
                informado = true;
                var tempAudioSource = this.GetComponent<AudioSource>();
                var tempAudioclip = tempAudioSource.clip;

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
