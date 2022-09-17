using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Train") && other.GetComponent<MovingController>().GetCurrentSpeed() == 0)
        {
            
        }
    }
}
