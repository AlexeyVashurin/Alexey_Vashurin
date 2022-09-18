using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrainCharacteristics : MonoBehaviour
    {
        
        
        [SerializeField]private int trainHealth;
        [SerializeField]private int boxCount;
        private MovingController _movingController;
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

        public IEnumerator DamageCoroutine()
        {
            while (trainHealth > 0)
            {
                trainHealth -= Random.Range(0,10);
                yield return new WaitForSeconds(3f);
            }
            
        }
        public void SetBoxCount(int box)
        {
            boxCount = boxCount+box;
        }
    }
}