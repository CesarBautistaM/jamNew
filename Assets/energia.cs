using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energia : MonoBehaviour
{
    private float energy = 100f;
    private RectTransform rectTransform;
    private bool bostezo, roncando;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //si tiene energia
        if (energy > 0)
        {
            //se le dice a la mano derecha y izquerda que tiene energia
            Movt_L_hand.energia = true;
            Movement_R_hand.energia = true;
            //y oprime alguna tecla del teclado
            if (Input.anyKeyDown == true)
            {
                if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
                {
                    //se le resta energia por cada vez que toca una tecla del teclado en este caso le deje 1 solo para testear
                    energy = energy - 1f;
                    //se baja la barra de energia
                    rectTransform.sizeDelta = new Vector2(100f, energy);
                }
            }
        }
        else
        {
            //en el caso que no tenga energia se le dice a la mano derecha e izquierda que no tiene energia
            Movt_L_hand.energia = false;
            Movement_R_hand.energia = false;
           
            if (GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && bostezo == false)
            {
                //y se repoduce el sonido de bostezo
                GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().Play();
                bostezo = true;
            }
            
            if(GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().isPlaying == false && roncando == false)
            {
                //cuando acabe el bostezo se reproduce los ronquios
                GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().Play();
                roncando = true;

            }
            if(GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().isPlaying == false && roncando == true && bostezo == true)
            {
                //despues de dormir se le da 5 de enrgia para que recarge en la cafeteria el cafe o si no se dormira de nuevo la idea es que mientras duerme pierda mucho tiempo
                bostezo = false;
                roncando = false;
                energy = 5f;
                rectTransform.sizeDelta = new Vector2(100f, energy);
            }
        }
        }
    
}
