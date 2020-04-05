using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class job_bar : MonoBehaviour
{
    private RectTransform rectTransform;
    private float trabajo = 100f;
    public static float trabajando { get; set; }

   void Start()
    {

        
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown == true)
        {
            if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
            {
                trabajo = trabajo - trabajando;
                rectTransform.sizeDelta = new Vector2(100f, trabajo);
            }
        }
    }
}
