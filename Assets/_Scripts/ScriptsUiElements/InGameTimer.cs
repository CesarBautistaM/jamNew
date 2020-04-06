﻿/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 02:22:14
Description:  Keeps track of the current ingame time
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] private Text clockDisplay;
    [SerializeField] private int timePassIncrements = 10;
    [SerializeField] private int startingDay = 1;


    [Range(0, 23)]
    [SerializeField] private int startingHour = 6;

    [Range(0, 59)]
    [SerializeField] private int startingMinute = 0;

    #endregion

    #region Private Variables

    private int _currentDay;
    private int _currentHour;
    private int _currentMinute;

    private bool _isClockTicking = false;

    public int CurrentDay { get => _currentDay; }
    public int CurrentHour { get => _currentHour; }
    public int CurrentMinute { get => _currentMinute; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Increase the clock timers
        if (!_isClockTicking)
            StartCoroutine(TickIngameTimer());


        // try to figure out if the player ran out of energy using @ProWarGamer's Shitty code :V
        if (GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().isPlaying == false && GameObject.FindObjectOfType<energia>().Roncando == true && GameObject.FindObjectOfType<energia>().Bostezo == true)
        {
            // Increase the timer by 3
            IncreaseTimerHours(3);
        }


    }

    #region Class Methods


    private IEnumerator TickIngameTimer()
    {
        this._isClockTicking = true;
        while (true)
        {
            this.TickTimer();
            this.UpdateClockDisplay();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void InitVariables()
    {
        this._currentDay = this.startingDay;
        this._currentHour = this.startingHour;
        this._currentMinute = this.startingMinute;
        this._isClockTicking = false;
        UpdateClockDisplay();
    }

    private void UpdateClockDisplay()
    {
        clockDisplay.text = string.Format("{2:D2} | {0:D2} : {1:D2}", this._currentHour, this._currentMinute, this._currentDay);
    }

    private void TickTimer()
    {
        var previousMinute = this._currentMinute;
        // Increase minutes
        this._currentMinute = HelpMethods.WrapNumber(0, 59, this._currentMinute + this.timePassIncrements);
        if (previousMinute > this._currentMinute)
        {
            // Increase Hours
            IncreaseTimerHours();
        }
    }

    private void IncreaseTimerHours(int times = 1)
    {
        // Increase Hours
        this._currentHour = HelpMethods.WrapNumber(0, 24, this._currentHour + 1 * times);
        // if (this._currentHour > HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times))
        // {
        //     this._currentHour = HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times);
        // }
    }

    #endregion
}