using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLeague : MonoBehaviour
{
    public List<string> teamNames;
    private List<string> pairs = new List<string>();
    int numberOfRounds;

    private List<int> teamList;

    void Start()
    {
        teamList = new List<int>();
        for (int i = 0; i < teamNames.Count; i++)
        {
            teamList.Add(i);
        }
        numberOfRounds = teamList.Count-1;
        Schedule();
        PrintSchedule();
    }

    void PrintSchedule()
    {
        foreach (var item in pairs)
        {
            print(item);
        }
    }

    void Schedule()
    {
        if (teamNames.Count % 2 != 0)
        {
            teamNames.Add("NULL");
        }

        int half = teamNames.Count / 2;

        for (int i = 0; i < numberOfRounds; i++)
        {
            for (int j = 0; j < half; j++)
            {
                int team1 = teamList[j];
                int team2 = teamList[teamNames.Count - 1 - j];

                if (team1 != -1 && team2 != -1)
                {
                    //Debug.Log("Round " + (i + 1) + ": " + teamNames[team1] + " vs. " + teamNames[team2]);
                    pairs.Add("Round " + (i + 1) + ": " + teamNames[team1] + " vs. " + teamNames[team2]);
                }
            }

            int lastTeam = teamList[teamNames.Count - 1];
            teamList.RemoveAt(teamNames.Count - 1);
            teamList.Insert(1, lastTeam);
        }
    }
}