using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dinero : MonoBehaviour
{
    public Text changinText;
    public GameObject changintwo;
    // Start is called before the first frame update
    void Start()
    {
        changintwo.GetComponent<Text>().text = "HELOO";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
