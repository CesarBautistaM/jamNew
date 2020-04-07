/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 02:22:14
Description:  Keeps track of the current ingame time
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour
{
    public static bool nuevodia { get; set; }
    #region Inspector Variables

    [SerializeField] private TextMesh dayDisplay;
    [SerializeField] private TextMesh clockDisplay;
    [SerializeField] private int timePassIncrements = 10;

    // [SerializeField] private int startingDay = 1;

    // [Range(0, 23)]
    // [SerializeField] private int startingHour = 6;

    // [Range(0, 59)]
    // [SerializeField] private int startingMinute = 0;

    [SerializeField] private DateTime startingGameDate = new DateTime(2020, 04, 01, 06, 00, 00);

    #endregion

    #region Private Variables
    private DateTime _currentIngameDateTime; // The current ingame date & time

    private bool _isClockTicking = false;
    // private int _currentDay;
    // private int _currentHour;
    // private int _currentMinute;

    public int CurrentDay { get => _currentIngameDateTime.Day; }
    public int CurrentHour { get => _currentIngameDateTime.Hour; }
    public int CurrentMinute { get => _currentIngameDateTime.Minute; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
        // Increase the clock timers
        // if (!_isClockTicking)
        StartCoroutine(TickIngameTimer());
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // try to figure out if the player ran out of energy using @ProWarGamer's Shitty code :V
        if (GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().isPlaying == false && GameObject.FindObjectOfType<energia>().Roncando == true && GameObject.FindObjectOfType<energia>().Bostezo == true)
        {
            // Increase the timer by 3
            IncreaseTimerHours(3);
        }
        if (nuevodia == true)
        {

            _currentIngameDateTime = new DateTime(2020, 04, CurrentDay, 06, 00, 00);
             nuevodia = false;
        }

        GameManager.dia = CurrentDay;
        GameManager.hora = CurrentHour;
        GameManager.min = CurrentMinute;

    }

    #region Class Methods

    private void InitVariables()
    {
        // this._currentDay = this.startingDay;
        // this._currentHour = this.startingHour;
        // this._currentMinute = this.startingMinute;

        this._currentIngameDateTime = this.startingGameDate;
        this._isClockTicking = false;
        UpdateClockDisplay();
    }

    private void UpdateDayDisplay()
    {

        dayDisplay.text = string.Format("{0:D2}", this._currentIngameDateTime.Day);
    }

    private void UpdateClockDisplay()
    {
        clockDisplay.text = string.Format("{0:D2} : {1:D2}", this._currentIngameDateTime.Hour, this._currentIngameDateTime.Minute);
    }

    private IEnumerator TickIngameTimer()
    {
        // this._isClockTicking = true;

        while (true)
        {
            this.TickTimer();
            this.UpdateClockDisplay();
            this.UpdateDayDisplay();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void TickTimer()
    {
        this._currentIngameDateTime = this._currentIngameDateTime.AddMinutes(this.timePassIncrements);
        // // Increase minutes
        // if (this._currentMinute > HelpMethods.WrapNumber(0, 59, this._currentMinute + this.timePassIncrements))
        // {
        //     this._currentMinute = HelpMethods.WrapNumber(0, 59, this._currentMinute + this.timePassIncrements);

        //     // Increase Hours
        //     IncreaseTimerHours();
        // }
    }

    private void IncreaseTimerHours(int times = 1)
    {

        this._currentIngameDateTime = this._currentIngameDateTime.AddHours(1 * times);

        // Increase Hours
        //     if (this._currentHour > HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times))
        //     {
        //         this._currentHour = HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times);
        //     }
        // }

        #endregion
    }

}