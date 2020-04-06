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
    public static double dinero { get; set; }
    public static int nivel { get; set; }
    
    public static GameManager instance = null;

    #region Inspector Variables

    [SerializeField] private int startingMoney = 0;

    [Range(0, 100)]
    [SerializeField] private int startingEnergy = 100;
    [SerializeField] private int startingWaterBillCost = 100;
    [SerializeField] private int startingGasBillCost = 100;
    [SerializeField] private int startingElectricityBillCost = 100;
    [SerializeField] private int startingInternetBillCost = 100;
    [SerializeField] private DateTime startingGameDate = new DateTime(2020, 04, 01, 06, 00, 00);

    #endregion

    #region Private Variables

    #region Player Variables

    private int _currentMoney; // The amount of money the player currently has
    private int _currentEnergy; // The amount of energy the player currently has
    private int _currentWaterBillCost; // The current cost for the given bill
    private int _currentGasBillCost; // The current cost for the given bill
    private int _currentElectricityBillCost; // The current cost for the given bill
    private int _currentInternetBillCost; // The current cost for the given bill
    private DateTime _currentIngameDateTime; // The current ingame date & time

    #endregion

    #region GameState
    private SceneChanger _sceneChanger;
    private bool _isGamePause = false;
    private bool _isGameRunning = false; // determines if we are currently inside the main game or not

    #endregion

    #endregion

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        this.InitGameValues();
    }


    // Start is called before the first frame update
    void Start()
    {
        Teclado.nivel++;
        dinero = 100;
        this._sceneChanger = this.GetComponent<SceneChanger>();   // Grab the scene changer that MUST be attached to the game manager object since
                                                                  // it's a requeires component
    }

    // Update is called once per frame
    void Update()
    {
        
        dinero = Math.Round(dinero, 2);
    }


    #region GameStateHanddler

    public bool IsGamePaused()
    {
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

    //Change the current scene to the given scene
    public void SetScene(GameScenesEnum scene)
    {
        this._sceneChanger.SetScene((int)scene);
    }

    #endregion

    #region GameplayHanddlers


    // Set the player's game value to it's original value
    private void InitGameValues()
    {
        this._currentEnergy = this.startingEnergy;
        this._currentMoney = this.startingMoney;
        this._currentMoney = 0;
        this._currentEnergy = 0;
        this._currentWaterBillCost = this.startingWaterBillCost;
        this._currentGasBillCost = this.startingGasBillCost;
        this._currentElectricityBillCost = this.startingElectricityBillCost;
        this._currentInternetBillCost = this.startingInternetBillCost;
        this._currentIngameDateTime = this.startingGameDate;
    }

    // Increase the game time by a set amount of seconds
    private void IncreaseGameTimerBySeconds()
    {
        this._currentIngameDateTime.AddSeconds(10);
    }

    // Increase the game time by 1 day
    private void IncreaseGameTimerByDay()
    {
        this._currentIngameDateTime.AddDays(1);
    }

    // increase the ingame timer by ten seconds every 1 second
    private IEnumerator TickIngameTimer()
    {
        this.IncreaseGameTimerBySeconds();
        return new WaitForSecondsRealtime(1);
    }

    public int getCurrentEnergy()
    {
        return this._currentEnergy;
    }

    public int getStartingEnergy()
    {
        return this.startingEnergy;
    }

    #endregion
}
