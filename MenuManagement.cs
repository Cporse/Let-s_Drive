using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    //Variables,
    public static MenuManagement Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void RecoreButton()
    {

    }
    public void ExitButton()
    {
        Application.Quit();
    }
}