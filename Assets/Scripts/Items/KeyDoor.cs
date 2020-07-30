using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType = Key.KeyType.Red;
    public int nextLevel;

    private Animator animator;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        FindObjectOfType<GameManager>().NextLevel(nextLevel);
    }
}
