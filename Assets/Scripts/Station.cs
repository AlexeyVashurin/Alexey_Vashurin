using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private ViewsHolder instance;

    private void Start()
    {
        instance = ViewsHolder.instance;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Train") && other.GetComponent<MovingController>().GetCurrentSpeed() == 0)
        {
            instance.StationInteractView.gameObject.SetActive(true);
        }
    }
}
