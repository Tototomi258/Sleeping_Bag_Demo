using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public List<Key.KeyType> keyList;
    private GameObject PlayScene;
    private bool isDone = false;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    private void Start()
    {
        PlayScene = GameObject.FindGameObjectWithTag("Level");
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        PlayScene.GetComponent<PlayScene>().hasKey = true;
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        PlayScene.GetComponent<PlayScene>().hasKey = false;
    }

    public bool ContainsKeys(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out Key key);
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        collision.TryGetComponent(out KeyDoor keyDoor);
        if (keyDoor != null && !isDone)
        {
            if (ContainsKeys(keyDoor.GetKeyType()))
            {
                isDone = true;
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }
    }
}
