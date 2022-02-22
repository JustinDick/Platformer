using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockRayCaster : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // draw a ray from the camera to the position of the mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if the ray hits the block
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject == this.gameObject)
                {
                    // call AddCoin in UI code
                    CoinScript.AddCoin();
                }
            }
        }
    }
}
