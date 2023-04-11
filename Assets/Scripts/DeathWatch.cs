using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathWatch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _result;
    [SerializeField] TextMeshProUGUI _maxAgeResult;

    public void Calculing()
    {
        //Формула расчёта и подсчёт

        //Вывод результатов
        _result.text = UserData.Instance.userInfo.Result.ToString();
        _maxAgeResult.text = UserData.Instance.userInfo.ResultMax.ToString();
    }    
}
