using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Text _yourResult;
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(()=>SceneManager.LoadScene(0));
        }

        public void SetTextResult(int boxCount)
        {
            _yourResult.text = "Ты собрал " + boxCount + " груз!";
        }
    }
}