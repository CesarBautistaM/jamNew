using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_R_hand : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {


        if (transform.position.x > -293 && transform.position.x < -143 && transform.position.y > -270 && transform.position.y < -127)
        {
            anim.SetBool("KeyBoard", true);
            if (Input.anyKeyDown == true)
            {
                if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
                {
                    anim.SetBool("PressKey", true);
                    job_bar.trabajando = 0.2f;
                }
            }
            else
            {
                anim.SetBool("PressKey", false);
                
            }
        }
        else
        {
            anim.SetBool("KeyBoard", false);
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = mousePosition.x - Camera.main.pixelWidth / 2;
        mousePosition.y = mousePosition.y - Camera.main.pixelHeight / 2;
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;

        
    }

    private void OnTriggerExit(Collider other)
    {
        click.enMouse = false;
    }
    private void OnTriggerStay(Collider colicion)
    {
        click.enMouse = true;
        //colicion con mouse
        if (colicion.gameObject.name.Equals("Mouse"))
        {
           
            Vector3 posicionMouse = colicion.GetComponent<Transform>().position;
            Vector3 posicionPuntero = GameObject.Find("Puntero").GetComponent<Transform>().position;
            


                if (Input.GetMouseButton(0) == true)
                {
                
                    if (transform.position.x > -70 && transform.position.x < 50 && transform.position.y < -215 && transform.position.y > -280)
                    {
                        
                        posicionMouse.x = transform.position.x;
                        posicionMouse.y = transform.position.y + 250;
                        posicionPuntero.x = posicionMouse.x * 2.5f - 240;
                        posicionPuntero.y = posicionMouse.y * (3) + 270;
                        colicion.GetComponent<Transform>().position = posicionMouse;
                        GameObject.Find("Puntero").GetComponent<Transform>().position = posicionPuntero;
                    }
                }


        }
       
        

        
    }
}
