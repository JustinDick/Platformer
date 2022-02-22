using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScript : MonoBehaviour
{
    private static int coinCount = 0;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            coinCount += 1;
        }
        coinText.text = " \n" + coinCount.ToString().PadLeft(2, '0');
    }

    public static void AddCoin()
    {
        coinCount += 1;
    }
}
