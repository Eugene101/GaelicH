using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tableau : MonoBehaviour
{
    bool timer;
    int s;
    int mins;
    int playerScore;
    int opponentScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI oppScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI oppName;
    public TextMeshProUGUI playerName;

    // Start is called before the first frame update

    private void Awake()
    {
        opponentScore = 0;
        playerScore = 0;
        oppScoreText.text = opponentScore.ToString();
        playerScoreText.text = playerScore.ToString();
    }

    private void Start()
    {
        StartTimer();
    }

    public void OppScore()
    {
        opponentScore++;
        oppScoreText.text = oppScoreText.ToString();
    }

    public void PlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        print("Vasyaooooooooo");
    }

    public void StartTimer()
    {
        InvokeRepeating("Timer", 1f, 1f);
    }
    void Timer()
    {
        if (!timer) { s++; }
        if (s > 59)
        {
            mins++; s = 00;
        }
        if (s < 10) { timerText.text = mins + ":0" + s; }
        else { timerText.text = mins + ":" + s; }
    }
}
