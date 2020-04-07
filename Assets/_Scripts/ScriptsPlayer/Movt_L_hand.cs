using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movt_L_hand : MonoBehaviour
{
    private bool PressKey;
    private Animator anim;
    private int mover = 1;

    public static bool energia { get; set; }
    public static bool enTeclado { get; set; }

    private AudioSource _tecladoAudioSource;
    private AudioClip _tecladoAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


        // store the audiosource and the sound effect
        this._tecladoAudioSource = GameObject.Find("Sound_keyboard").GetComponent<AudioSource>();
        this._tecladoAudioClip = this._tecladoAudioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //se revisa que no se este oprimiendo ninguna tecla del mouse
        if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
        {

            //se revisa que tenga energia
            if (energia == true)
            {

                //en el caso que oprima una tecla se setea 
                PressKey = Input.anyKeyDown;
                //si no tiene la mano deracha en el teclado se setea el trabajo en 0.1 significa en la mitad para que relice el trabajo mas lento
                if (enTeclado == false)
                {
                    job_bar.trabajando = 0.1f;
                }
                //se setea la animacion
                anim.SetBool("PressKey", PressKey);
            }
            else
            {
                //se setea la animacion
                anim.SetBool("PressKey", false);
            }
        }
    }
    private void FixedUpdate()
    {
        //si oprime una tecla
        if (PressKey == true)
        {

            //y tiene energia
            if (energia == true)
            {

                // GameObject.Find("Sound_keyboard").GetComponent<AudioSource>().Play();

                // play the keyboard sound
                this._tecladoAudioSource.PlayOneShot(this._tecladoAudioClip);

                //se obtiene su posicion 
                Vector3 position = transform.position;
                //se setean los limites en que se va a mover
                if (position.x < -428)
                {
                    mover = -10;
                }
                if (position.x > -372)
                {
                    mover = 10;
                }
                //y se mueve la mano izquierda
                position.x = position.x - mover;

                transform.position = position;
            }
            else
            {
                GameObject.Find("Sound_keyboard").GetComponent<AudioSource>().Pause();
            }
        }
        else
        {
            GameObject.Find("Sound_keyboard").GetComponent<AudioSource>().Pause();
        }
    }
}
