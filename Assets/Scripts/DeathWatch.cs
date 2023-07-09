using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathWatch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _result;
    [SerializeField] TextMeshProUGUI _maxAgeResult;
    [SerializeField] TextMeshProUGUI _curAge;
    [SerializeField] Slider _slider;

    public int CurrentAge;  //текущий возраст
    public int MaxAge;      // Максимальный возраст в зависимости от пола

    public string Sex;      // Пол
    public int Result;      // Сколько осталось
    public int ResultMax;   // До скольки доживёшь

    private void Awake()
    {
        _slider.onValueChanged.AddListener(CurrentAgeInput);
    }

    public void Calculing()
    {
        //Формула расчёта и подсчёт
        if (Sex == "M")
        {
            ResultMax = 80;
        }
        else
        {
            ResultMax = 90;
        }

        Result = ResultMax - CurrentAge;

        //Вывод результатов
        UserData.Instance.userInfo.years = Result;
        _result.text = Result.ToString();
        _maxAgeResult.text = ResultMax.ToString();
    }

    public void ChoiceSex(string Key)
    {
        Sex = Key;
    }

    void CurrentAgeInput(float value)
    {
        CurrentAge = (int)value;
        _curAge.text = value.ToString();
    }
}
