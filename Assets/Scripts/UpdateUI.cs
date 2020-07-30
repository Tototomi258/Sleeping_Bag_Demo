using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpdateUI : MonoBehaviour
{
    public GameObject KeysUI;
    public GameObject LevelsText;
    public GameObject Slider;
    public GameObject ScoreText;

    public void SetUI(bool hasKey, int levelsCount, float timer, float score)
    {
        KeysUI.gameObject.SetActive(hasKey);
        LevelsText.GetComponent<TextMeshProUGUI>().text = "Level: " + levelsCount;
        Slider.GetComponent<Slider>().value = timer;
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + (int)Mathf.Round(score);
    }
}
