using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerPvE : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Enemy;
    private Vector3 EnemySpawn;
    private int Score;
    public Text ScoreTracker;
    void Start()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        EnemySpawn.y = -2.73f;
        Score = 0;
        ScoreTracker.text = Score.ToString();
        SpawnEnemy();
    }

    public void RegisterEnemyDeath()
    {
        Score++;
        ScoreTracker.text = Score.ToString();
        Invoke("SpawnEnemy", 2);
    }

    public void SpawnEnemy()
    {
        EnemySpawn.x = Random.Range(6.5f, 13.5f);
        Instantiate(Enemy, EnemySpawn, Enemy.transform.rotation, null);
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
}
