using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text scoreText, scoreBoard;
    public GameObject backGround, playButton, instrucciones, scoreBText;
    public FInalScript finalTile;
    public SpawnerScript spawn;

    private bool isPlaying;
    private int score;

    private FileWriter writer;

    private void Awake()
    {
        writer = GetComponent<FileWriter>();
    }

    public void Play()
    {
        score = 0;
        scoreBoard.text = "";
        scoreText.text = score.ToString();

        makeUiVisible( false );

        finalTile.ResetLife();
        spawn.StartGame();

        isPlaying = true;
    }

    public void GameOver()
    {
        makeUiVisible( true );
        spawn.StopGame();

        scoreBoard.text = writer.LoadHigscores(score);

        isPlaying = false;
    }

    public void IncreaseScore()
    {
        if (isPlaying)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void makeUiVisible( bool UIStatte )
    {
        backGround.SetActive(UIStatte);
        playButton.SetActive(UIStatte);
        instrucciones.SetActive(UIStatte);
        scoreBText.SetActive(UIStatte);
    }
}
