using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class llenarcafe : MonoBehaviour
{
    public static bool  llenar { set; get; }
    private bool transicion;
    private Color color;
    private int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        transicion = false;
        color = GameObject.Find("Negro").GetComponent<RawImage>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (llenar == true)
        {
            
            
            if (color.a < 1 && contador==0 && transicion == false)
            {
                
                color.a = color.a + 0.005f;
                GameObject.Find("Negro").GetComponent<RawImage>().color = color;
                if (Math.Truncate(color.a) == 1)
                {
                    transicion = true;
                    color.a = Convert.ToSingle(Math.Truncate(color.a));
                    
                }
            }
           
            if(color.a == 1 && contador == 0 && transicion == true)
            {
                energia.cafe = true;
                Vector3 posCamera = GameObject.Find("Main Camera").GetComponent<Transform>().position;
                posCamera.x = 3050;
                GameObject.Find("Main Camera").GetComponent<Transform>().position = posCamera;
                color.a = color.a - 0.001f;
                
            }
            if (color.a > 0 && color.a < 1 && contador == 0 && transicion == true )
            {
                
                color.a = color.a - 0.005f;
                GameObject.Find("Negro").GetComponent<RawImage>().color = color;
               

            }
            if (color.a < 0 && transicion == true && contador >= 0 && contador <= 1170)
            {
               
                GameObject.Find("cafetera").GetComponent<Animator>().SetBool("Servir", true);
                contador = contador + 1;
                if (contador >= 1000)
                {
                    contador = 1170;
                    
                }

                if(contador == 1170)
                {
                    
                    GameObject.Find("cafetera").GetComponent<Animator>().SetBool("Servir", false);
                    GameObject.Find("cafetera").GetComponent<Animator>().speed = 1;
                    transicion = false;
                    energia.energy = 100f;
                   
                    contador++;
                }
            }
            if(contador == 1171)
            {

                if (color.a < 1 && transicion == false)
                {
                    
                    color.a = color.a + 0.005f;
                    GameObject.Find("Negro").GetComponent<RawImage>().color = color;
                    if (Math.Truncate(color.a) == 1)
                    {
                        transicion = true;
                        color.a = Convert.ToSingle(Math.Truncate(color.a));
                       
                    }
                }

                if (color.a == 1 && transicion == true)
                {
                    energia.cafe = true;
                    Vector3 posCamera = GameObject.Find("Main Camera").GetComponent<Transform>().position;
                    posCamera.x = -67;
                    GameObject.Find("Main Camera").GetComponent<Transform>().position = posCamera;
                    color.a = color.a - 0.001f;
                    llenar = false;

                }
                
                if (color.a > 0 && color.a < 1 && transicion == true)
                {

                    color.a = color.a - 0.005f;
                    GameObject.Find("Negro").GetComponent<RawImage>().color = color;
                   
                    energia.cafe = false;
                    llenar = false;
                    transicion = false;
                    contador = 0;
                }
            }

        }
        
    }
}
