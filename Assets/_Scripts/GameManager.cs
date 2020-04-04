/*
Author: Andres Mrad (Q-ro)
Date: Saturday 04/April/2020 @ 15:40:19
Description:  The game manager 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneChanger))]
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    #region Inspector Variables

    #endregion

    #region Private Variables

    private SceneChanger sceneChanger;

    #endregion

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.sceneChanger = this.GetComponent<SceneChanger>();   // Grab the scene changer that MUST be attached to the game manager object since
                                                                 // it's a requeires component
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region GameHanddler

    //Change the current scene to the given scene number
    public void setScene(GameScenesEnum scene)
    {
        this.sceneChanger.setScene((int)scene);
    }

    #endregion
}
