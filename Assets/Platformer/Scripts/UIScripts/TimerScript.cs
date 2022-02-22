using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float countdown = 300f;
    private float accumulatedTime = 0f;
    public TMP_Text timerText;
    //public TextMeshPro timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;

        if (accumulatedTime > 1f)
        {
            accumulatedTime = 0f;

            if (countdown > 0)
            {
                countdown -= 1f;
            }
        }

        if (countdown <= 15)
        {
            if (countdown%2 == 0)
            {
                timerText.color = Color.red;
            }

            else
            {
                timerText.color = Color.white;
            }
        }

        else if (countdown <= 60)
        {
            timerText.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            countdown -= 20f;
        }

        timerText.text = "TIME \n" + countdown;

    }
}
