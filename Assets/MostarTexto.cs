using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostarTexto : MonoBehaviour
{
    private Color colortexto; 
    // Start is called before the first frame update
    void Start()
    {
        colortexto = this.GetComponent<TextMesh>().color;
        colortexto.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        colortexto.r = 1;
        colortexto.g = 0.3f;
        colortexto.b = 0.3f;
        this.GetComponent<TextMesh>().color = colortexto;
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
