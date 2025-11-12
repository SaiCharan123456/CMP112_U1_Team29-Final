using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class EndPoint : MonoBehaviour
{

    [SerializeField] GameObject LevelComplete;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Keys == 3)
            {
                Time.timeScale = 0f;
                LevelComplete.SetActive(true);
                scoreText.text = GameManager.Score.ToString();
                coinText.text = GameManager.Coins.ToString();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
