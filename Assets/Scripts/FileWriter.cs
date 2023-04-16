using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileWriter : MonoBehaviour
{
    public string scoreFile;

    [HideInInspector] public string newScoreHilights;

    private void Start()
    {
        newScoreHilights = "";
    }

    public string LoadHigscores(int newScore)
    {
        List<int> scores = ReadScoreFile();
        scores = UpdateScore(newScore, scores);
        updateHilightText(newScore, scores);
        WriteScores(scores);
        return getStringFromListScores(scores);
    }

    List<int> UpdateScore(int newScore, List<int> scores)
    {
        bool added = false;

        for (int i = 0; i < scores.Count; i++)
        {
            if (newScore > scores[i] && !added)
            {
                scores.Insert(i, newScore);
                added = true;
                scores.RemoveAt(scores.Count - 1);
            }
        }

        return scores;
    }

    List<int> ReadScoreFile()
    {
        List<int> scores = new List<int>();
        string[] lines = System.IO.File.ReadAllLines(scoreFile);
        for (int i = 0; i < lines.Length; i++)
        {
            scores.Add(int.Parse(lines[i]));
        }
        return scores;
    }



    void WriteScores(List<int> scores)
    {
        File.WriteAllText(scoreFile, string.Empty);
        File.AppendAllText(scoreFile, scores[0].ToString());

        for (int i = 1; i < scores.Count; i++)
        {
            File.AppendAllText(scoreFile, Environment.NewLine + scores[i].ToString());
        }
    }

    string getStringFromListScores(List<int> scores)
    {
        List<string> stringScores = new List<string>();
        foreach (int num in scores)
        {
            stringScores.Add(num.ToString() + "\n");
        }

        string result = string.Join("", stringScores);

        return result;
    }

    void updateHilightText(int newScore, List<int> scores)
    {
        bool added = false;
        newScoreHilights = "";

        for (int i = 0; i < scores.Count; i++)
        {
            if (newScore == scores[i] && !added)
            {
                newScoreHilights = newScoreHilights + scores[i].ToString() + "\n";
                added = true;
            }
            else
            {
                newScoreHilights = newScoreHilights + "\n";
            }
        }
    }

}
