using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class FixTrainView : MonoBehaviour
    {
        [SerializeField] private Button _fixButton;
        private TrainCharacteristics trainCharacteristics;

        private void Start()
        {
            trainCharacteristics = TrainCharacteristics.instance;
            _fixButton.onClick.AddListener(() =>
            {
                trainCharacteristics.TrainRecovery();
            });
        }
    }
}