using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public int health = 10;
    public int score = 0;
    public int keysCollected = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
