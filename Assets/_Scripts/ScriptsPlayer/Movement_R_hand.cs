using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_R_hand : MonoBehaviour
{
    private Animator anim;
    public static bool energia { get; set; }
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
        //Se verifica que tiene energia
        if (energia == true)
        {
            //Se verifica se encuentra en las cordenadas donde esta el teclado
            if (transform.position.x > -293 && transform.position.x < -143 && transform.position.y > -270 && transform.position.y < -127)
            {
                //Se llama al animador y se setea la variable
                anim.SetBool("KeyBoard", true);
                //se le indica a la mano izquierda que tiene la mano en el teclado
                Movt_L_hand.enTeclado = true;
                //se verifica si se oprimio cualquier tecla
                if (Input.anyKeyDown == true)
                {
                    //se verifica no se oprimio los botones del mouse para que solo cuenten los del mouse
                    if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
                    {
                        //Se llama al animador y se setea la variable
                        anim.SetBool("PressKey", true);
                        //se llama al job_bar.cs y se setea la variable trabajo esta es la que por cada click en el mouse cuanto se va a sumar para que aumente (este se encuentra en el canvas job)
                        job_bar.trabajando = 0.2f;
                        
                    }
                }
                //si no oprime ninguna tecla se setea el animador en falso para que deje de hacer la animacion
                else
                {
                    anim.SetBool("PressKey", false);

                }
            }
            //si no se encuentra en la posicion del teclado se setea el animador en falso para que deje de hacer la animacion
            else
            {

                anim.SetBool("KeyBoard", false);
                //se le indica a la mano izquierda que no tiene la mano en el teclado
                Movt_L_hand.enTeclado = true;
            }

            //se mueve la mano del personaje con el mouse
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.x = mousePosition.x - Camera.main.pixelWidth / 2;
            mousePosition.y = mousePosition.y - Camera.main.pixelHeight / 2;
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
        }
        //si no tiene energia se setea el animador en falso para que deje de hacer la animacion y ademas no se puede mover por que el movimiento esta dentro del if
        else
        {
            anim.SetBool("PressKey", false);
        }

    }

    private void OnTriggerExit(Collider colicion)
    {
        //se setea el enMouse del click.cs (GameObject/Puntero) para que sepa que no estamos tocando el mouse y asi solo si tocamos el mouse y damos click ejecuta los iconos 
        if (colicion.gameObject.name.Equals("Mouse"))
        {
            click.enMouse = false;
        }
    }
    private void OnTriggerStay(Collider colicion)
    {
        if (energia == true)
        {
            if (colicion.gameObject.name.Equals("MugNescafe"))
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    if (GameManager.dinero >= 1.99)
                    {
                        
                        llenarcafe.llenar = true;
                    }

                }
            }


            if (colicion.gameObject.name.Equals("Precio_limpiador"))
            {
                if (Input.GetMouseButtonDown(0) == true)
                {
                    if (GameManager.dinero >= 5.9)
                    {
                        GameManager.dinero = GameManager.dinero - 5.9;
                        Teclado.limpiador = true;
                    }

                }
            }

            //se verifica que este colicionando con el mouse
            if (colicion.gameObject.name.Equals("Mouse"))
            {
                //se setea el enMouse del click.cs (GameObject/Puntero) para que sepa que no estamos tocando el mouse y asi solo si tocamos el mouse y damos click ejecuta los iconos 
                click.enMouse = true;
                //Se obtiene la posicion de tanto el mouse como el puntero
                Vector3 posicionMouse = colicion.GetComponent<Transform>().position;
                Vector3 posicionPuntero = GameObject.Find("Puntero").GetComponent<Transform>().position;


                //Se verifica que tengamos el click izquiero oprimido para mover el mouse y el puntero
                if (Input.GetMouseButton(0) == true)
                {
                    //se declara la zona para que el mouse no pueda salir de ahi
                    if (transform.position.x > -70 && transform.position.x < 50 && transform.position.y < -215 && transform.position.y > -280)
                    {
                        //se le da al mouse la misma cordenada que tiene la mano en x
                        posicionMouse.x = transform.position.x;
                        //se le da al mouse la misma cordenada que tiene la mano en y pero se le suma 250 ya que el y se toma desde la parte mas baja del brazo
                        posicionMouse.y = transform.position.y + 250;

                        //se le da al puntero la misma cordenada que tiene el mouse en x pero se multiplica para que abarque todo el monitor y se le resta el dezface
                        posicionPuntero.x = posicionMouse.x * 2.4f - 250;
                        //se le da al puntero la misma cordenada que tiene el mouse enyx pero se multiplica para que abarque todo el monitor y se le resta el dezface
                        posicionPuntero.y = posicionMouse.y * (3) + 260;

                        //Se le setea el pocicion del mouse
                        colicion.GetComponent<Transform>().position = posicionMouse;
                        //Se le setea el pocicion del cursor
                        GameObject.Find("Puntero").GetComponent<Transform>().position = posicionPuntero;
                    }
                }

            }
        }
    }
}

 
       
        

        
    

