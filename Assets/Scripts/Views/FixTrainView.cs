using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class FixTrainView : MonoBehaviour
    {
        [SerializeField] private Button FixButton;
        private TrainCharacteristics trainCharacteristics;

        private void Start()
        {
            trainCharacteristics = TrainCharacteristics.instance;
            FixButton.onClick.AddListener(() =>
            {
                trainCharacteristics.TrainRecovery();
            });
        }
    }
}