using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Day : MonoBehaviour
{
    public TextMesh textmesh;

    public int day=1;

    void Start()
    {
        textmesh = GetComponent<TextMesh>();
       
    }

    // Update is called once per frame
    void Update()
    {
        day++;

        textmesh.text = (day.ToString());
        
       
         }

        void Predetermined()
        {
        textmesh.text = ("1");       
        }


}


