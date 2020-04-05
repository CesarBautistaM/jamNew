using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public static bool enMouse { get; set; }
    public static bool cmdOpen { get; set; }
    
    void Start()
    {
        GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = false;
        cmdOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider icono)
    {
        if(Input.GetMouseButtonDown(0)==true && enMouse == true)
        {
            if (icono.gameObject.name.Equals("SprIcon_Job"))
            {
                GameObject.Find("cmd").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        
    }
}
