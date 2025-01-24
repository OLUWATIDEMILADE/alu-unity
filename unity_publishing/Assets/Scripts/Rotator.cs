using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Making the coin rotate along the x-axis at a 45 degree speed
        transform.Rotate(45 * Time.deltaTime, 0, 0);

    }
}
