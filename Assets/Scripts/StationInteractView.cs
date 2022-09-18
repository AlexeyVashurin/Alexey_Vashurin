using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class StationInteractView: MonoBehaviour
{
    [SerializeField] private Button _takeBox;
    private TrainCharacteristics trainCharacteristics;

    private void Start()
    {
        trainCharacteristics = TrainCharacteristics.instance;
        _takeBox.onClick.AddListener(()=>
        {
            trainCharacteristics.SetBoxCount(1);
            gameObject.SetActive(false);
        });
    }
}