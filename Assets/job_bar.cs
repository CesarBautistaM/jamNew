using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class job_bar : MonoBehaviour
{
    private RectTransform rectTransform;
    private float trabajo = 100f;
    public static float trabajando { get; set; }
    public static bool activo { get; set; }

    void Start()
    {

        GameObject.Find("Job").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Job_bar").GetComponent<RawImage>().enabled = false;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Job").GetComponent<RawImage>().enabled = activo;
        GameObject.Find("Job_bar").GetComponent<RawImage>().enabled = activo;
        if (Input.anyKeyDown == true && GameObject.Find("Job").GetComponent<RawImage>().enabled == true)
        {
            if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
            {
                trabajo = trabajo - trabajando;
                rectTransform.sizeDelta = new Vector2(100f, trabajo);
            }
        }
    }

    private void FixedUpdate()
    {
        if (trabajo < 0)
        {
            activo = false;
            cmd.activo = false;
            rectTransform.sizeDelta = new Vector2(100f, 100f);
            trabajo = 100f;
        }
    }
}
