using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    public GameObject Player, Camera, Level, UpdateUI;

    public float score = 100;

    private float targetTimer;
    private float timer;
    private bool movesLevel = true;

    public bool hasKey;
    public int currentLevel;

    public bool move = false;

    private void Start()
    {
        //Set active scene and start timer

        SceneManager.SetActiveScene(gameObject.scene);
        targetTimer = Random.Range(6, 10);
        UpdateUI = GameObject.Find("UI");
    }

    private void Update()
    {
        if (move)
        {
            float progress = timer / targetTimer;
            UpdateUI.GetComponent<UpdateUI>().SetUI(hasKey, currentLevel, progress, score);

            if (score > 0)
            {
                score -= Time.deltaTime * 2;
            }
            else
            {
                score = 0;
            }

            if (movesLevel)
            {
                Level.GetComponent<Floor_Movement>().move = true;
                Player.GetComponent<CharacterMovement>().move = false;
                Camera.SetActive(false);

                if(timer >= targetTimer)
                {
                    movesLevel = !movesLevel;
                    targetTimer = Random.Range(3, 5);
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
            else
            {
                Level.GetComponent<Floor_Movement>().move = false;
                Player.GetComponent<CharacterMovement>().move = true;
                Camera.SetActive(true);

                if (timer >= targetTimer)
                {
                    movesLevel = !movesLevel;
                    targetTimer = Random.Range(6, 10);
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<GameManager>().totalScore += Mathf.RoundToInt(score);
    }
}
