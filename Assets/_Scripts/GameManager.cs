/*
Author: Andres Mrad (Q-ro)
Date: Saturday 04/April/2020 @ 15:40:19
Description:  The game manager 
*/

using System;
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

    private SceneChanger _sceneChanger;

    private bool _isGamePause = false;

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
        this._sceneChanger = this.GetComponent<SceneChanger>();   // Grab the scene changer that MUST be attached to the game manager object since
                                                                  // it's a requeires component
    }

    // Update is called once per frame
    void Update()
    {

    }


    #region GameHanddler

    public bool IsGamePaused()
    {
        Debug.Log("is game paused ? : " + _isGamePause);
        Debug.Log("is game paused (instance) ? " + GameManager.instance._isGamePause);
        return this._isGamePause;
    }

    public void PauseGame()
    {
        this._isGamePause = true;
        Time.timeScale = (this._isGamePause) ? 0 : 1;
    }

    public void UnpauseGame()
    {
        this._isGamePause = false;
        Time.timeScale = (this._isGamePause) ? 0 : 1;
    }

    //Change the current scene to the given scene number
    public void setScene(GameScenesEnum scene)
    {
        this._sceneChanger.setScene((int)scene);
    }

    #endregion
}
