using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Animator animator;
    public GameObject PlayScene, LoadingScreen, PauseScreen, UpdateUI, MenuScreen, Player, Camera;

    public bool gamePaused = false;

    public int totalScore;
    private int highScore;

    private void Awake()
    {
        Instance = this;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //Main Menu
    }

    private void Update()
    {
        //Pause Game

        if (gamePaused)
        {
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PauseScreen.SetActive(false);
        }
    }

    public void StartGame()
    {
        UpdateUI.SetActive(true);
        StartCoroutine(LoadNextLevel(2));
    }

    public void NextLevel(int level)
    {
        if (level == 1)
        {
            MainMenu();
        } 
        else
        {
            StartCoroutine(LoadNextLevel(level));
            gamePaused = false;
            UpdateUI.SetActive(true);
        }
    }

    public IEnumerator LoadNextLevel(int level)
    {
        animator.SetBool("Start", true);

        yield return new WaitForSeconds(1f);

        //Unload scene & load selected scene

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.3f);

        //Find PlayScene controller and set to true

        PlayScene = GameObject.FindGameObjectWithTag("Level");
        PlayScene.GetComponent<PlayScene>().move = true;
        animator.SetBool("Start", false);

        yield return null;
    }

    public void MainMenu()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        UpdateUI.SetActive(false);
        gamePaused = false;

        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        if (totalScore >= highScore)
        {
            highScore = totalScore;
            Invoke("HighScore", 0.2f);
        }
    }

    private void HighScore()
    {
        MenuScreen = GameObject.FindGameObjectWithTag("Menu");
        MenuScreen.GetComponentInChildren<Menu>().UpdateHighScore(highScore);
        totalScore = 0;
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
    }
}
