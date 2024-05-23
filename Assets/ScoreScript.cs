using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int score = 0;
    public static TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {        
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
