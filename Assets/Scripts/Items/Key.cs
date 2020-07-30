using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType = KeyType.Red;
    public enum KeyType
    {
        Red,
        Blue,
        Green
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
