using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class router : MonoBehaviour
{
    private Animator anim;
    public static bool bug { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bug == true)
        {
            anim.SetBool("error", true);
        }
        else
        {
            anim.SetBool("error", false);
        }
    }
}
