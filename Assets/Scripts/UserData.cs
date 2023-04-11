using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Все данные пользователя, которые будут использоваться. 
//Требуется добавить: образ жизни, вредные привычки, питание, болезни? А также сделать норм формулу
[System.Serializable]
public class UserInfo
{
    public int CurrentAge;  //текущий возраст
    public int MaxAge;      // Максимальный возраст в зависимости от пола
    public int Result;      // Сколько осталось
    public int ResultMax;   // До скольки доживёшь
    public string Sex;      // Пол
}

public class UserData : MonoBehaviour
{
    public UserInfo userInfo;
    public static UserData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
