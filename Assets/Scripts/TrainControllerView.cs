using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainControllerView : MonoBehaviour
{
    [SerializeField] private Button _сhangeCameraMode;
    [SerializeField] private Scrollbar _trainSpeedScrollbar;
    [SerializeField] private MovingController _movingController;
    [SerializeField] private TrainCharacteristics _trainCharacteristics;


    void Start()
    {
        _trainSpeedScrollbar.onValueChanged.AddListener(arg0 => ChangeSpeedValue());
    }
    void ChangeSpeedValue()
    {
        _movingController.SetCurrentSpeed(_trainSpeedScrollbar.value * 5);
    }
    public void SetScrollbarNull()
    {
        _trainSpeedScrollbar.value = 0;
    }
}