using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Данные только для таймера
[System.Serializable]
public class UserInfo
{
    public int years;
    public int days;
    public int hours;
    public int minutes;
    public float seconds;
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
