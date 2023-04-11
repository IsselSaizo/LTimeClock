using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class Languages : MonoBehaviour
{
    public string LanguageName;
    public static Languages Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLanguage(string Name)
    {
        LanguageName = null;
        LanguageName = Name;
        InternationalText.IsLanguageChanged();
    }
}
