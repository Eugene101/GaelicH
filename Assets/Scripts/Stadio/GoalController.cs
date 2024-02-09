using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using TMPro;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Haptics;

public class GoalController : MonoBehaviour
{
    public static int playerScore;
    public static int enemyScore;
    public static bool timer = true;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI oppScoreText;
    public TextMeshProUGUI oppName;
    public TextMeshProUGUI playerName;
    int mins = 0;
    int s = 0;
    SetPosition setPosition;
    bool isGoal = false;

    // Start is called before the first frame update

    private void Start()
    {
        setPosition = GetComponent<SetPosition>();
        UxrAvatar myAvatar = UxrAvatar.LocalAvatar;
        InvokeRepeating("Timer", 1f, 1f);
    }

    public void PlayerScored()
    {
        if (!isGoal)
        {
            playerScore++;
            //print("Score: " + playerScore + "-" + enemyScore);
            playerScoreText.text = playerScore.ToString();
            Invoke("GoToPosition", 2f);
            isGoal = true;
            Invoke("GoalReset", 5f);
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }
        

    }

    public void EnemyScored()
    {
        if (!isGoal)
        {
            enemyScore++;
            oppScoreText.text = enemyScore.ToString();
            //print("Score: " + playerScore + "-" + enemyScore);
            Invoke("GoToPosition", 2f);
            isGoal = true;
            Invoke("GoalReset", 5f);
        }
    }

    void GoalReset()
    {
        isGoal = false;
    }    

    public void GoToPosition()
    {
        setPosition.SetPos();
    }

    void Timer()
    {
        
        
        if (timer == true) { s++; }
        if (s > 59)
        {
            mins++; s = 00;
        }
        if (s < 10) { timerText.text = mins + ":0" + s; }
        else { timerText.text = mins + ":" + s; }
    }



}
