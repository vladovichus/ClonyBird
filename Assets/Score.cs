using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text mText;
    static int score = 0;
    static int highScore = 0;

    static Score instance;
    public static void AddPoint()
    {
        if (instance.bird.dead)
            return; 
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
    }

    BirdMovement bird;
    
    void Start()
    {
        instance = this;
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");
        if (player_go == null)
        {
            Debug.LogError("Counld not fing go tagged  player");
        }
        bird = player_go.GetComponent<BirdMovement>();
        score = 0;
       highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void OnDestroy()
    {
        instance = null;
        PlayerPrefs.SetInt("highScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "Score: " + score + "\nHigh Score: " + highScore;
    }
}