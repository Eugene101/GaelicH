using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static Competitions competitions;
    public static int currentOpponentNumb;
    public static string currentOpponentName;
    public GameObject currentOpponent;
    public GameObject rivalsController;
    RivalsController rivalsControllerScript;

    private void Awake()
    {
        rivalsControllerScript = rivalsController.GetComponent<RivalsController>();
    }
    public void MatchButton()
    {
        competitions = Competitions.Match;
        currentOpponentNumb = Random.Range(0, rivalsControllerScript.names.Length);
        currentOpponentName = rivalsControllerScript.names[currentOpponentNumb];
        currentOpponent = rivalsControllerScript.rivalPrefabs[currentOpponentNumb];
        PlayerPrefs.SetInt("IntValue", currentOpponentNumb);
        PlayerPrefs.SetString("StringValue", currentOpponentName);
        LoadPlay();
    }

    public void LeagueButton()
    {
        competitions = Competitions.League;
        LoadPlay();
    }

    public void ChampButton()
    {
        competitions = Competitions.Championship;
        LoadPlay();
    }

    void LoadPlay()
    {
        SceneManager.LoadScene("Dodgeball");
    }
}
