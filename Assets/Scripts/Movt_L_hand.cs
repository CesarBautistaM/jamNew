using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movt_L_hand : MonoBehaviour
{
    private bool PressKey;
    private Animator anim;
    private int mover = 1;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false)
        {
            PressKey = Input.anyKeyDown;

            anim.SetBool("PressKey", PressKey);
        }
       
    }
    private void FixedUpdate()
    {
   
        if (PressKey == true)
        {
            Vector3 position = transform.position;
            if (position.x < -428)
            {
                mover = -10;
            }
            if (position.x > -372)
            {
                mover = 10;
            }

            position.x = position.x - mover;

            transform.position = position;
        }
    }
}
