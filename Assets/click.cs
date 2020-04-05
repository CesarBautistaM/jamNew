using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public static bool enMouse { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider icono)
    {
        if(Input.GetMouseButtonDown(0)==true && enMouse == true)
        {
            Debug.Log("col");
        }
        
    }
}
