using System.Collections;
using TMPro;
using UnityEngine;

public class scrollText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed = 10f;
    public GameObject parent;
    public GameObject mainMenu;

    private Vector3 startPosition;

    private RectTransform rect;

    private Coroutine co;

    private void Awake()
    {
        rect = text.GetComponent<RectTransform>();
    }

    public void StartScroll()
    {
        co = StartCoroutine(Scroll());
    }

    private IEnumerator Scroll()
    {
        float height = 1770;
        startPosition = rect.position;

        float scrollPosition = 0f;

        while (rect.position.y < height)
        {
            rect.position = new Vector3(startPosition.x, scrollPosition % height, startPosition.z);

            scrollPosition += speed * 15 * Time.deltaTime;

            yield return null;
        }

        parent.SetActive(false);
        mainMenu.SetActive(true);
        rect.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        StopCoroutine(co);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            parent.SetActive(false);
            mainMenu.SetActive(true);
            rect.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
            StopCoroutine(co);
        }
    }
}
