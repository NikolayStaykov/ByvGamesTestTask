using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPGameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject ContinueButton;
    void Start()
    {
        PauseMenu.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void ContinueGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); 
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void GameEnd()
    {
        Time.timeScale = 0;
        ContinueButton.SetActive(false);
        PauseMenu.SetActive(true);
    }

}
