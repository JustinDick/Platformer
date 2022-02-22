using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimation : MonoBehaviour
{
    private float accumulatedTime = 0f;
    private float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;

        if (accumulatedTime > 0.08)
        {
            counter += 0.2f;
            accumulatedTime = 0;
            Material mat = GetComponent<MeshRenderer>().material;
            mat.mainTextureOffset = mat.mainTextureOffset + new Vector2(0f, counter);
        } 
    }
}
