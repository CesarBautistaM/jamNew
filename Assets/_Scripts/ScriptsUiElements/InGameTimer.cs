/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 02:22:14
Description:  Keeps track of the current ingame time
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTimer : MonoBehaviour
{

    #region Inspector Variables

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
        TickTimer();

        // try to figure out if the player ran out of energy using @ProWarGamer's Shitty code :V
        //@ProWarGamer Is a shit code but funcional code 
        if (GameObject.Find("Sonido_bostezo").GetComponent<AudioSource>().isPlaying == false && GameObject.Find("Sonido_roncando").GetComponent<AudioSource>().isPlaying == false && GameObject.FindObjectOfType<energia>().Roncando == true && GameObject.FindObjectOfType<energia>().Bostezo == true)
        {
            // Increase the timer by 3
            IncreaseTimerHours(3);
        }
        

    }

    #region Class Methods

    private void InitVariables()
    {
        this._currentDay = this.startingDay;
        this._currentHour = this.startingHour;
        this._currentMinute = this.startingMinute;
    }

    private void TickTimer()
    {
        // Increase minutes
        if (this._currentMinute > HelpMethods.WrapNumber(0, 59, this._currentMinute + this.timePassIncrements))
        {
            this._currentMinute = HelpMethods.WrapNumber(0, 59, this._currentMinute + this.timePassIncrements);

            // Increase Hours
            IncreaseTimerHours();
        }
    }

    private void IncreaseTimerHours(int times = 1)
    {
        // Increase Hours
        if (this._currentHour > HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times))
        {
            this._currentHour = HelpMethods.WrapNumber(0, 59, this._currentHour + 1 * times);
        }
    }

    #endregion
}