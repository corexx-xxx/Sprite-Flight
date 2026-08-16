using UnityEngine.UIElements;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIDocument uiDocument;
    private Label highScoreText;

    int highScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreText = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");
        highScoreText.text = "최고점수: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            Debug.Log("High Score: " + highScore);
        }
        else
        {
            Debug.Log("No high score found.");
        }
    }

    public void SaveHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            Debug.Log("New high score saved: " + score);
            highScoreText.text = "최고점수: " + score;
        }
    }
}
