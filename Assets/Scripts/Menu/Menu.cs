using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject scoreText;

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }
    public void PlayGame()
    {
        GameManager.Instance.StartGame();
    }

    public void UpdateHighScore(int highScore = 0)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + highScore.ToString();
    }
}
