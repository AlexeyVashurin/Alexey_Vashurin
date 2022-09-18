using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ViewsHolder : MonoBehaviour
{
    public static ViewsHolder instance { get; private set; }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            // DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }


    public StationInteractView StationInteractView;
    public TrainControllerView TrainControllerView;
    public FixTrainView FixTrainView;
    public GameOverView GameOverView;
}