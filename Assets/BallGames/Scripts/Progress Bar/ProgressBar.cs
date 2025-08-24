using UnityEngine;
using UnityEngine.UI;

namespace BucketMove
{
    public class ProgressBar : MonoBehaviour
    {
        public Image SlideBar;
        public int totalSteps = 10;

        private int currentStep = 0;
        public void IncreaseProgress()
        {
            currentStep++;
            float progress = Mathf.Clamp01((float)currentStep / totalSteps);
            SlideBar.fillAmount = progress;
        }
        public void ResetProgress()
        {
            currentStep = 0;
            SlideBar.fillAmount = 0f;
        }
        
    }
}
