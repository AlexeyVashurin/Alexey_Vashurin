using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private ViewsHolder instance;
    private bool boxAvialible;

    private void Start()
    {
        instance = ViewsHolder.instance;
        boxAvialible = true;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Train") && other.GetComponent<MovingController>().GetCurrentSpeed() == 0 && boxAvialible)
        {
            instance.StationInteractView.gameObject.SetActive(true);
            boxAvialible = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            instance.StationInteractView.gameObject.SetActive(false);
            boxAvialible = true;
        }
    }
}
