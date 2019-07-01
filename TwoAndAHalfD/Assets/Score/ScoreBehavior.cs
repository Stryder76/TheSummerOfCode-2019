using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gameObject = GameObject.Find("ScoreText");
        
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var text = "Score: " + score;
        if (scoreText.text != text) {
            scoreText.text = text;
        }
            
    }




}
