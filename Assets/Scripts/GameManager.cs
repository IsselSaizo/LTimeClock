using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CalculateLoad()
    {
        SceneManager.LoadScene("Calculating");
    }

    public void ClockLoad()
    {
        SceneManager.LoadScene("DeathWatch");
    }

    public void ChangeLanguage(string LanguageName)
    {
        FindObjectOfType<Languages>().ChangeLanguage(LanguageName);
    }
}
