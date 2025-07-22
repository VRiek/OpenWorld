using TMPro;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public void setScoreText(int number)
    {
        score += number;
        scoreText.text = score.ToString();
    }
}
