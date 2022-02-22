using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            score += 100;
        }
        scoreText.text = "MARIO \n" + score.ToString().PadLeft(6, '0'); 
    }
}
