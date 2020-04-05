using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public TextMesh textmesh;

    public int money=350;

    void Start()
    {
        textmesh = GetComponent<TextMesh>();
       
    }

    // Update is called once per frame
    void Update()
    {
        money++;

        textmesh.text = ("$"+money.ToString());
        
       
         }

        void Predetermined()
        {
        textmesh.text = ("350");       
        }


}


