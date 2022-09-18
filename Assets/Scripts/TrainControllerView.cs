using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainControllerView : MonoBehaviour
{
    [SerializeField] private Button _сhangeCameraMode;
    [SerializeField] private Scrollbar _trainSpeedScrollbar;
    [SerializeField] private MovingController _movingController;

    void Start()
    {
        _trainSpeedScrollbar.onValueChanged.AddListener(arg0 => ChangeSpeedValue());
    }
    void ChangeSpeedValue()
    {
        _movingController.SetCurrentSpeed(_trainSpeedScrollbar.value*5);
    }
}