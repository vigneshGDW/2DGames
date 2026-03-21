using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LiftManagementSystem
{
    public class LiftController : MonoBehaviour
    {
        public GameObject[] Floors;
        public int CurrentFloor = 0;
        public bool LiftState = false;
        private float elapsedTime = 0f;
        public float MovingDuration = 2f;

        public Queue<int> floorQueue = new Queue<int>();

        public void LiftGoFun(int targetFloor)
        {
            // Ignore if already at that floor
            if (CurrentFloor == targetFloor)
            {
                Debug.Log("Already at floor " + targetFloor);
                return;
            }

            // Ignore if already in queue
            if (floorQueue.Contains(targetFloor))
            {
                Debug.Log("Floor already in queue: " + targetFloor);
                return;
            }

            floorQueue.Enqueue(targetFloor);// add the floor number

            if (!LiftState)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            while (floorQueue.Count > 0)// Lift move floor by floor for based on queue
            {
                int targetFloor = floorQueue.Dequeue();
                yield return StartCoroutine(LiftMovingTarget(CurrentFloor, targetFloor));
            }
        }

        private IEnumerator LiftMovingTarget(int currentFloor, int targetFloor)//Moveing targetfloor
        {
            LiftState = true;
            elapsedTime = 0f;

            Vector3 startPos = Floors[currentFloor].transform.position;
            Vector3 targetPos = Floors[targetFloor].transform.position;

            while (elapsedTime < MovingDuration)
            {
                float t = elapsedTime / MovingDuration;
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
            CurrentFloor = targetFloor;//Updtate current floor
            LiftState = false;
        }
    }
}