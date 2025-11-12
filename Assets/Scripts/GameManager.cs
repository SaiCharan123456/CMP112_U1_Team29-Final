using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject key1, key2, key3;
    [SerializeField] GameObject star1, star2, star3;
    [SerializeField] GameObject heart0, heart1, heart2, heart3;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelCompleteScreen;


    private bool isPaused = false;

    [SerializeField] float startTime = 300f;
    private float remainingTime;
    private bool isRunning = false;



    public static int Health;
    public static int Score = 0;
    public static int Coins = 0;
    public static int Keys = 0;
    private bool isGameOver = false;
    //private bool isGameWon = false;

    [SerializeField] GameObject Enddoor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = 4;
        heart0.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        key1.gameObject.SetActive(false);
        key2.gameObject.SetActive(false);
        key3.gameObject.SetActive(false);

        remainingTime = startTime;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                isRunning = false;
                TimerEnded();
            }

            UpdateTimerDisplay();
        }

        scoreText.text = Score.ToString();
        coinText.text = Coins.ToString();

        switch (Health)
        {
            case 4:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 3:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
                //default:
                //    heart0.gameObject.SetActive(false);
                //    heart1.gameObject.SetActive(false);
                //    heart2.gameObject.SetActive(false);
                //    heart3.gameObject.SetActive(false);
                //    break;
        }

        if (Keys == 1)
        {
            key1.SetActive(true);
        }
        else if (Keys == 2)
        {
            key1.SetActive(true);
            key2.SetActive(true);
        }
        else if (Keys == 3)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
                
 
        }

        if (Health <= 0 && !isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
            DisplayStars();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;         
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f;          
        isPaused = false;
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        remainingTime = startTime;
        UpdateTimerDisplay();
    }

    public void DisplayStars()
    {
        if (Keys == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else if (Keys == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else if (Keys == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (Keys == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    } 

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Health = 4;
        Keys = 0;
        Score = 0;
        Coins = 0;
        ResetTimer();
        SceneManager.LoadScene(1);
    }

    void TimerEnded()
    {
        isGameOver = true;
        PauseGame();
        gameOverScreen.SetActive(true);
        DisplayStars();

    }
}
