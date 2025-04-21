using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChiikawaClicker : MonoBehaviour 
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public GameObject startPanel;
    public Button startButton;

    public RectTransform[] characterImages;

    private int score = 0;
    private float timer = 30f;
    private bool gameActive;

    void Start()
    {
        gameActive = false;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);

    }
    public void StartGame()
    {
        score = 0;
        timer = 30f;
        gameActive = true;

        scoreText.text = "Score: 0";
        timerText.text = "Time: 30";

        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        SpawnCharacter();
    }


    void Update()
    {
        if (!gameActive) return;

        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString(); //ondalıklı sayıyı yuvarlıyor 9.99 -> 10
        if (timer <= 0)
        {
            gameActive = false;
            
            for (int i = 0;i < characterImages.Length;i++) {

                characterImages[i].gameObject.SetActive(false);
            }
            timerText.text = "Time's up!";
            gameOverPanel.SetActive(true);

        }
    }
    public void onChiikawaClicked()
    {
        if (!gameActive) return;

        score++;
        scoreText.text = "Score: " + score.ToString();
        SpawnCharacter();

    }
    public void RestartGame()
    {
        score = 0;
        timer = 30f;
        gameActive = true;
        scoreText.text = "Score: ";
        gameOverPanel.SetActive(false);
        SpawnCharacter();


    }
    void SpawnCharacter()
    {
        for (int i = 0; i < characterImages.Length; i++)
        {
            characterImages[i].gameObject.SetActive(false);
        }

        int randomIndex = Random.Range(0, characterImages.Length);
        characterImages[randomIndex].gameObject.SetActive(true);

        float randomX = Random.Range(-300f, 300f);
        float randomY = Random.Range(-200f, 200f);
        characterImages[randomIndex].anchoredPosition = new Vector2(randomX, randomY);
    }

}
