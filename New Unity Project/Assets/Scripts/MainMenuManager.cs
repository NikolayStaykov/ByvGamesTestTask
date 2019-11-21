using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void LoadPvPScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadPvEScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
