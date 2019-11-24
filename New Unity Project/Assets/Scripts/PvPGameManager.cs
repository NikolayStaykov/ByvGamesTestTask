using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPGameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject ContinueButton;
    public GameObject FirstAidKit;
    public GameObject Bomb;
    public GameObject Shield;
    public GameObject Bazooka;
    public bool SpawnItemAllowed;
    void Start()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        SpawnItemAllowed = true;
        Invoke("SpawnItem", 3);
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

    private void SpawnItem()
    {
        if (SpawnItemAllowed)
        {
            int ItemToSpawn = Random.Range(1, 5);
            switch (ItemToSpawn)
            {
                case 1:
                    Instantiate(FirstAidKit, Vector3.zero, FirstAidKit.transform.rotation, null);
                    break;
                case 2:
                    Instantiate(Bomb, Vector3.zero, Bomb.transform.rotation, null);
                    break;
                case 3:
                    Instantiate(Shield, Vector3.zero, Shield.transform.rotation, null);
                    break;
                case 4:
                    Instantiate(Bazooka, Vector3.zero, Bazooka.transform.rotation, null);
                    break;
            }
            SpawnItemAllowed = false;
            Invoke("SpawnItem", 6);
        }
        else
        {
            Invoke("SpawnItem", 3);
        }
    }
}
