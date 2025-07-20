using System;
using UnityEngine;

namespace BucketMove.Level_4
{
    public class BallWinScript4 : MonoBehaviour
    {
        public GameObject[] ColorGlows;
        public int count = 0;
        public ProgressBar progressBar;
        public String ChooseStringname;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                if (count == 0)
                {
                    ChooseStringname = other.gameObject.name;
                    count += 1;
                    other.gameObject.SetActive(false);
                }
                else
                {
                    if (ChooseStringname == other.gameObject.name)
                    {
                        count += 1;
                        other.gameObject.SetActive(false);
                        progressBar.IncreaseProgress();
                        if (count == 11)
                        {
                            Debug.Log("Win-------------:)-->");
                        }
                    }
                    else
                    {
                        Debug.Log("Resetfun");
                        other.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
