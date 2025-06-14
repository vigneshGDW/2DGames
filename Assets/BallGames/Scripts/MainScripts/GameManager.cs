using UnityEngine;

namespace BucketMove
{
    public class GameManager : MonoBehaviour
    {
        public Canvas StartCanwas, TaskCanwas, CongratsCanwas, FailurCanwas;
        public Canvas Level1;

        void Start()
        {
            if (!StartCanwas.gameObject.activeSelf)
            {
                StartCanwas.gameObject.SetActive(true);
            }
        }

        public void PlayFunctions()
        {
            StartCanwas.gameObject.SetActive(false);
            TaskCanwas.gameObject.SetActive(true);
        }
        public void LevelStartFunction()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(true);
        }

        public void LevelCompleted()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(true);
        }
        public void LevelFailure()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(true);
        }
        public void HomeButfun()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(true);
        }
        public void LevelResetfun()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(true);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
        }
    }
}
