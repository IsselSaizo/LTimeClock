using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Для таймера
    int years = 0;
    int days = 0;
    int hours = 0;
    int minutes = 0;
    float seconds = 0;
    int sec;

    [SerializeField] TextMeshProUGUI secondsTime;
    [SerializeField] TextMeshProUGUI minutesTime;
    [SerializeField] TextMeshProUGUI hoursTime;
    [SerializeField] TextMeshProUGUI daysTime;
    [SerializeField] TextMeshProUGUI yearsTime;

    //Для дейликов
    string keyK;
    int valueK;
    int valueFood;
    int valueSleep;
    int valueSport;

    [SerializeField] GameObject DailyUI;
    [SerializeField] TextMeshProUGUI sum;

    private void Start()
    {
        years = UserData.Instance.userInfo.years;
        days = UserData.Instance.userInfo.days;
        hours = UserData.Instance.userInfo.hours;
        minutes = UserData.Instance.userInfo.minutes;
        seconds = UserData.Instance.userInfo.seconds;
        secondsTime.text = seconds.ToString();
        UpdateTime();
        
    }

    private void Update()
    {
        TimerLife();
    }

    //Get Time from Calculating
    void TimerLife()
    {
        seconds -= Time.deltaTime;
        sec = (int)seconds;
        secondsTime.text =  sec.ToString();
        SetTime();
        if (seconds < 0)
        {
            if (minutes > 0)
            {
                minutes -= 1;
                seconds += 59;
                UpdateTime();
            }
            else
            {
                if(hours > 0)
                {
                    hours -= 1;
                    minutes += 59;
                    seconds += 59;
                    UpdateTime();
                }
                else
                {
                    DailyUI.SetActive(true);
                    sum.text = "";
                    if(days > 0)
                    {
                        days -= 1;
                        hours += 23;
                        minutes += 59;
                        seconds += 59;
                        UpdateTime();
                    }
                    else
                    {
                        if(years > 0)
                        {
                            years -= 1;
                            days += 364;
                            hours += 23;
                            minutes += 59;
                            seconds += 59;
                            UpdateTime();
                        }
                        else
                        {
                            StopTimer();
                        }
                    }
                }
            }
        }
    }

    void UpdateTime()
    {
        minutesTime.text = minutes.ToString();
        hoursTime.text = hours.ToString();
        daysTime.text = days.ToString();
        yearsTime.text = years.ToString();
    }

    void SetTime()
    {
        UserData.Instance.userInfo.years = years;
        UserData.Instance.userInfo.days = days;
        UserData.Instance.userInfo.hours = hours;
        UserData.Instance.userInfo.minutes = minutes;
        UserData.Instance.userInfo.seconds = seconds;
    }

    void StopTimer()
    {
        secondsTime.text = "";
        return;
    }



    //Дейлики
    void Daily()
    {
        if (keyK == "Food")
        {
            valueFood = valueK;
        }
        else if (keyK == "Sleep")
        {
            valueSleep = valueK;
        }
        else if(keyK == "Sport")
        {
            valueSport = valueK;
        }
    }

    public void GetKey(string key)
    {
        keyK = key;
    }

    public void GetValue(int value)
    {
        valueK = value;
        Daily();
    }

    public void ApplyDaily()
    {
        int summari = valueFood + valueSleep + valueSport;
        minutes += summari;
        if (minutes/60 >= 1 && minutes % 60 > 1)
        {
            minutes -= 60;
            hours += 1;
        }
        else if (minutes < 0)
        {
            minutes += 60;
            hours -= 1;
        }
        sum.text = summari.ToString();
        DailyUI.SetActive(false);
        UpdateTime();
    }

    public void TestDaysSpeedrun()
    {
        hours -= 13;
        if (hours < 0)
        {
            days -= 1;
            hours += 24;
            DailyUI.SetActive(true);
            sum.text = "";
        }
        UpdateTime();
    }
}
