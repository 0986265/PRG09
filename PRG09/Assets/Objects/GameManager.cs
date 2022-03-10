using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TMP_Text UIScoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        UIScoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
