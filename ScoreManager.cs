using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int score;
    public static TMP_Text scoreText;
    public static ScoreManager scoreManager;

    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        if(scoreManager != null)
            GameObject.Destroy(scoreManager);
        else
            scoreManager = this;
		
        DontDestroyOnLoad(this);
    }
    
    public static void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
