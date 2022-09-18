using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrainCharacteristics : MonoBehaviour
    {
        
        
        [SerializeField]private int trainHealth;
        [SerializeField]private int boxCount;
        private MovingController _movingController;
        private ViewsHolder _viewsHolder;
        public static TrainCharacteristics instance { get; private set; }

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);

            _movingController = GetComponent<MovingController>();
            _viewsHolder = ViewsHolder.instance;
        }

        public void SetDamage()
        {
            if (_movingController.GetCurrentSpeed() > 0)
            {
                StartCoroutine(DamageCoroutine());  
            }
        }

        public void StopDamage()
        {
            StopAllCoroutines();
        }

        private IEnumerator DamageCoroutine()
        {
            while (trainHealth > 0)
            {
                trainHealth -= Random.Range(0,10);
                yield return new WaitForSeconds(3f);
            }
            _viewsHolder.FixTrainView.gameObject.SetActive(true);
            _movingController.SetCurrentSpeed(0);
            _viewsHolder.TrainControllerView.gameObject.SetActive(false);
        }

        public void TrainRecovery()
        {
            if (trainHealth <=0)
            {
                StartCoroutine(RecoveryCoroutine());
            }
        }

        private IEnumerator RecoveryCoroutine()
        {
            while (trainHealth <100)
            {
                trainHealth += 20;
                yield return new WaitForSeconds(1f);
            }
            _viewsHolder.FixTrainView.gameObject.SetActive(false);
            _viewsHolder.TrainControllerView.gameObject.SetActive(true);
            _viewsHolder.TrainControllerView.SetScrollbarNull();
            StopAllCoroutines();
        }

        public void SetBoxCount(int box)
        {
            boxCount = boxCount+box;
        }
    }
}