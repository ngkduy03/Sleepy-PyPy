using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ToLv1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ToLv2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
