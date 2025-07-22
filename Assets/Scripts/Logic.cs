using TMPro;
using UnityEngine;

public class Logic : MonoBehaviour
{
    private int score = 0;
    public bool isPaused = false;
    public TextMeshProUGUI scoreText;
    public GameObject pauseScreen;

    private void Update()
    {
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }    
    }

    public void setScoreText(int number)
    {
        score += number;
        scoreText.text = score.ToString();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseScreen.SetActive(isPaused);
    }
}
