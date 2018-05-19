using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerScoreProgress : MonoBehaviour {

    private string highScoreString;
    private List<int> highScoreValues;
    public TextMeshProUGUI highScoreText;

    void Start () {

        highScoreValues = new List<int>() {0,0,0,0,0,0,0};

        if (PlayerPrefs.HasKey("HighScores"))
        {
            highScoreString = PlayerPrefs.GetString("HighScores");
        }
        else // First time setup
        {
            highScoreString = "0\n0\n0\n0\n0\n0\n0";
        }

        string[] tempStr = highScoreString.Split('\n');
        for (int i = 0; i < tempStr.Length; ++i)
        {
            highScoreValues[i] = Int32.Parse(tempStr[i]);
        }

    }

    public void AddScore(int score)
    {

        for (int i = 0; i < 7; ++i)
        {
            if (score > highScoreValues[i])
            {
                highScoreValues.Insert(i, score);
                break;
            }
        }

        string[] tmpStr = new string[7];
        for (int j = 0; j < tmpStr.Length; ++j)
        {
            tmpStr[j] = highScoreValues[j].ToString();
        }

        highScoreString = String.Join("\n", tmpStr);
        PlayerPrefs.SetString("HighScores", highScoreString);
        highScoreText.SetText(highScoreString);
    }
	
}
