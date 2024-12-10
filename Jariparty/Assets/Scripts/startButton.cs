using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("diddy party");
    }

    // Update is called once per frame
    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings"); 
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
