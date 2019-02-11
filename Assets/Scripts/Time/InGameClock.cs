using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameClock : MonoBehaviour {

    //The values can be Serialize when not needed to clean everything up
    //The clock runs on the combination of DeltaTime and the update loop so whereever this ends up so long
    //its placed in "Update" it will be fine
    //To create a day night cycle I think you can just change a light intensity depending on the time of day

    public float timeScale = 1;
    public float time;
    [SerializeField]
    private float _rawTime, _second, _minute, _hour, _day, _month, _year;

    //Following varibles unused 
    [SerializeField]
    private float _totalSeconds, _totalMinutes, _totalHours, _totalDays, _totalMonths, _totalYears;

    private string _padded24Hour, _padded24Minute;

    void Start()
    {
        //set all values to "The start of time"
        _year = _month = _day = _hour = _minute = _second = 0;
        _totalYears = _totalMonths = _totalDays = _totalHours = _totalMinutes = _totalSeconds = 0;
        _padded24Hour = "";
        _padded24Minute = "";
    }

    void Update()
    {
        CalculateTime();
        TwentyFourHourClock();
    }

    void TwentyFourHourClock()
    {
        _padded24Hour = _hour.ToString().PadLeft(2, '0');
        _padded24Minute = _minute.ToString().PadLeft(2, '0');
        string totalTime = "[" + _padded24Hour + ":" + _padded24Minute + "]";

        time = _hour + _minute / 100;

        //Debug.Log("The time is " + totalTime);
    }

    void CalculateTime()
    {
        //Rawtime is raw update with deltime
        _rawTime += Time.deltaTime * timeScale;

        //The following is how each increment of time is worked out, its fairly easy to follow
        if (_rawTime >= 1)
        {
            _second++;
            _totalSeconds++;
            _rawTime = 0;
        }

        if (_second >= 60)
        {
            _minute++;
            _totalMinutes++;
            _second = 0;
        }

        if (_minute >= 60)
        {
            _hour++;
            _totalHours++;
            _minute = 0;
        }

        if (_hour >= 24)
        {
            _day++;
            _totalDays++;
            _hour = 0;
        }

        if (_day >= 31)
        {
            _month++;
            _totalMonths++;
            _day = 0;
        }

        if (_month >= 12)
        {
            _year++;
            _totalYears++;
            _month = 0;
        }

    }
}
