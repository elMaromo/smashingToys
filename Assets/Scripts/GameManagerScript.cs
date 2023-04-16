using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text scoreText, scoreBoard, scoreHilights;
    public GameObject playButton;
    public GameObject BackgroundImage;
    public FInalScript finalTile;
    public SpawnerScript spawn;

    private int score;
    

    public void Play()
    {
        score = 0;
        scoreBoard.text = "";
        scoreHilights.text = "";
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        BackgroundImage.SetActive(false);

        finalTile.ResetLife();
        //UnPause();
    }
}
