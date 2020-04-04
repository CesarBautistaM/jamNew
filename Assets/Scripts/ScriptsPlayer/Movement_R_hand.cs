using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        
            
            if (transform.position.x>-293 && transform.position.x < -143 && transform.position.y > -270 && transform.position.y < -127) { 
                anim.SetBool("KeyBoard", true);
                if (Input.anyKeyDown == true)
                {
                    if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false)
                    {
                        anim.SetBool("PressKey", true);
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
        mousePosition.x = mousePosition.x - Camera.main.pixelWidth/2;
        mousePosition.y = mousePosition.y - Camera.main.pixelHeight / 2;
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }
}
