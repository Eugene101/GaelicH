using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class csvLoader : MonoBehaviour
{
    public TextAsset csvFile; // The CSV file to be loaded

    // Arrays to store the parsed data
    public float[] Speed;
    public float[] enemyShootAccuracy;
    public float[] enemyRechargeTime;
    public float[] TendencyToShoot;

    // Start is called before the first frame update
    void Start()
    {
        LoadCSVFile(csvFile);
    }

    // Load the CSV file and parse the data into arrays
    private void LoadCSVFile(TextAsset csv)
    {
        string[] lines = csv.text.Split('\n'); // Split the file into lines
        Speed = new float[lines.Length];
        enemyShootAccuracy = new float[lines.Length];
        enemyRechargeTime = new float[lines.Length];
        TendencyToShoot = new float[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(','); // Split the line into values

            // Parse the values into the appropriate arrays
            float speedValue, accuracyValue, rechargeTimeValue, tendencyValue;
            if (float.TryParse(values[0], out speedValue))
            {
                Speed[i] = speedValue;
            }
            if (values.Length > 1 && float.TryParse(values[1], out accuracyValue))
            {
                enemyShootAccuracy[i] = accuracyValue;
            }
            if (values.Length > 2 && float.TryParse(values[2], out rechargeTimeValue))
            {
                enemyRechargeTime[i] = rechargeTimeValue;
            }
            if (values.Length > 3 && float.TryParse(values[3], out tendencyValue))
            {
                TendencyToShoot[i] = tendencyValue;
            }
        }
    }
}