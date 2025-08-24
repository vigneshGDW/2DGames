using System.Collections;
using BucketMove.Level_1;
using UnityEngine;

namespace BucketMove.Level_2
{
    public class ShapesController : MonoBehaviour
    {
        public GameObject[] AllShapes;
        public int LeanthofEnd;
        public BallFallScript ballFallScript;

        private void Start()
        {
            StartCoroutine(BallShapeChangeLoop());
        }

        private IEnumerator BallShapeChangeLoop()
        {
            while (true)
            {
                if (LeanthofEnd == ballFallScript.ColorBalls.Length)
                {
                    Debug.Log("You Lose!");
                    yield break; 
                }

                for (int k = 0; k < AllShapes.Length; k++)
                {
                    AllShapes[k].SetActive(true);
                    yield return new WaitForSeconds(5f);
                    AllShapes[k].SetActive(false);
                }
            }
        }
    }
}
