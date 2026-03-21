using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LiftManagementSystem
{
    public class LiftManager : MonoBehaviour
    {
        public LiftController[] Lifts;

        private HashSet<int> activeRequests = new HashSet<int>();

        public void PlayerPressButton(int targetFloor)
        {
            // Prevent duplicate requests
            if (activeRequests.Contains(targetFloor))
            {
                Debug.Log("Already requested floor: " + targetFloor);
                return;
            }

            activeRequests.Add(targetFloor);// add the floor number to active request

            LiftController bestLift = null;
            int shortestDistance = int.MaxValue;// Find the maximum distance
            // check near one for free lift
            foreach (var lift in Lifts)
            {
                int distance = Mathf.Abs(lift.CurrentFloor - targetFloor);

                if (!lift.LiftState && distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestLift = lift;
                }
            }

            // If all lift engaged, after find to  assign to the one with shortest distance
            if (bestLift == null)
            {
                foreach (var lift in Lifts)
                {
                    int distance = Mathf.Abs(lift.CurrentFloor - targetFloor);

                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        bestLift = lift;
                    }
                }
            }

            if (bestLift != null)
            {
                bestLift.LiftGoFun(targetFloor);// assign the lift for target floor
                StartCoroutine(ClearRequest(bestLift, targetFloor));
            }
        }

        private IEnumerator ClearRequest(LiftController lift, int floor)
        {
            // Wait until lift finishes movement
            while (lift.LiftState)
                yield return null;

            activeRequests.Remove(floor);
        }
    }
}