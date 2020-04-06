using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texto : MonoBehaviour
{
    private Color colortexto = GameObject.Find("Texto_cafe").GetComponent<TextMesh>().color;
    // Start is called before the first frame update
    void Start()
    {
        colortexto.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (energia.energy < 10)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Nescafe_vacio").GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Nescafe_vacio").GetComponent<SpriteRenderer>().enabled = false;
        }
        colortexto.r = 1;
        colortexto.g = 0.3f;
        colortexto.b = 0.3f;
        GameObject.Find("Texto_cafe").GetComponent<TextMesh>().color = colortexto;
    }
    private void OnTriggerStay(Collider other)
    {
        colortexto.a = 1;
        
    }
    private void OnTriggerExit(Collider other)
    {
        colortexto.a = 0;
    }
}
