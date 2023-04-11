using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;
    [SerializeField] string _tr;

    public static bool IsChanged = false;

    private void Start()
    {
        OnChanged();
    }

    private void Update()
    {
        if (IsChanged)
        {
            OnChanged();
            IsChanged = false;
        }
    }

    public void OnChanged()
    {
        if (Languages.Instance.LanguageName == "en")
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
        else if (Languages.Instance.LanguageName == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else if (Languages.Instance.LanguageName == "tr")
        {
            GetComponent<TextMeshProUGUI>().text = _tr;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }

    public static void IsLanguageChanged()
    {
        IsChanged = true;
    }
}
