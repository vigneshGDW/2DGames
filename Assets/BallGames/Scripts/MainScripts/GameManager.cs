using BucketMove.Level_1;
using Unity.VisualScripting;
using UnityEngine;

namespace BucketMove
{
    public class GameManager : MonoBehaviour
    {
        public Canvas StartCanwas, TaskCanwas, CongratsCanwas, FailurCanwas;
        public Canvas Level1,Level2,Level3,Level4,Level5;
        public bool Level1Win, Level2Win, Level3Win, Level4Win, Level5Win;
        public GameObject Task1show, Task2show, Task3show, Task4show, Task5show;

        public BallFallScript Level1Resetfun;
        void Start()
        {
            // if (!StartCanwas.gameObject.activeSelf)
            // {
            //     StartCanwas.gameObject.SetActive(true);
            // }
        }

        public void PlayFunctions()
        {
            TaskCanwas.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
            if (!Level1Win)
            {
                TaskCanwas.gameObject.SetActive(true);
                Task1show.SetActive(true);
            }
            else if (!Level2Win)
            {
                TaskCanwas.gameObject.SetActive(true);
                Task2show.SetActive(true);
                Task1show.SetActive(false);
            }
            else if (!Level3Win)
            {
                TaskCanwas.gameObject.SetActive(true);
                Task3show.SetActive(true);
                Task2show.SetActive(false);
            }
            else if (!Level4Win)
            {
                StartCanwas.gameObject.SetActive(true);
                Level1Win = false;
                Level2Win = false;
                Level3Win = false;
            }
            else if (!Level5Win)
            {
                TaskCanwas.gameObject.SetActive(true);
                Task5show.SetActive(true);
                Task4show.SetActive(false);
            }
        }
        public void LevelStartFunction()
        {
            TaskCanwas.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
            if (Level1Win == false)
            {
                Level1.gameObject.SetActive(true);
            }
            else if (Level2Win == false)
            {
                Level2.gameObject.SetActive(true);
            }
            else if (Level3Win == false)
            {
                Level3.gameObject.SetActive(true);
            }
            else if (Level4Win == false)
            {
                Level4.gameObject.SetActive(true);
            }
            else if (Level5Win == false)
            {
                Level5.gameObject.SetActive(true);
            }
        }

        public void LevelCompleted()
        {
            TaskCanwas.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
            if (!Level1Win)
            {
                Level1.gameObject.SetActive(false);
                CongratsCanwas.gameObject.SetActive(true);
            }
            else if (!Level2Win)
            {
                Level2.gameObject.SetActive(false);
                CongratsCanwas.gameObject.SetActive(true);
            }
            else if (!Level3Win)
            {
                Level3.gameObject.SetActive(false);
                CongratsCanwas.gameObject.SetActive(true);
            }
            else if (!Level4Win)
            {
                Level4.gameObject.SetActive(false);
                CongratsCanwas.gameObject.SetActive(true);
            }
            else if (!Level5Win)
            {
                Level5.gameObject.SetActive(false);
                CongratsCanwas.gameObject.SetActive(true);
            }
        }
        public void LevelFailure()
        {
            TaskCanwas.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
            if (!Level1Win)
            {
                Level1.gameObject.SetActive(false);
                FailurCanwas.gameObject.SetActive(true);
            }
            else if (!Level2Win)
            {
                Level2.gameObject.SetActive(false);
                FailurCanwas.gameObject.SetActive(true);
            }
            else if (!Level3Win)
            {
                Level3.gameObject.SetActive(false);
                FailurCanwas.gameObject.SetActive(true);
            }
            else if (!Level4Win)
            {
                Level4.gameObject.SetActive(false);
                FailurCanwas.gameObject.SetActive(true);
            }
            else if (!Level5Win)
            {
                Level5.gameObject.SetActive(false);
                FailurCanwas.gameObject.SetActive(true);
            }
        }
        public void HomeButfun()
        {
            TaskCanwas.gameObject.SetActive(false);
            Level1.gameObject.SetActive(false);
            Level2.gameObject.SetActive(false);
            Level3.gameObject.SetActive(false);
            Level4.gameObject.SetActive(false);
            Level5.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(true);
        }
        public void LevelResetfun()
        {
            TaskCanwas.gameObject.SetActive(false);
            CongratsCanwas.gameObject.SetActive(false);
            FailurCanwas.gameObject.SetActive(false);
            StartCanwas.gameObject.SetActive(false);
            if (!Level1Win)
            {
                Level1.gameObject.SetActive(true);
            }
            else if (!Level2Win)
            {
                Level2.gameObject.SetActive(true);
            }
            else if (!Level3Win)
            {
                Level3.gameObject.SetActive(true);
            }
            else if (!Level4Win)
            {
                Level4.gameObject.SetActive(true);
            }
            else if (!Level5Win)
            {
                Level5.gameObject.SetActive(true);
            }
        }
    }
}
