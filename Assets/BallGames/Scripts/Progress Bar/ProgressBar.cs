using UnityEngine;
using UnityEngine.UI;

namespace BucketMove
{
        public class ProgressBar : MonoBehaviour
        {
            [SerializeField] private Slider slider;
            [SerializeField] private Text progressText; // Optional

            // Set value between 0 and 1
            public void SetProgress(float progress)
            {
                progress = Mathf.Clamp01(progress); // Ensures value is between 0 and 1
                slider.value = progress;

                if (progressText != null)
                {
                    progressText.text = (progress * 100f).ToString("F0") + "%";
                }
            }

            // Call this to set instantly to full
            public void SetFull()
            {
                SetProgress(1f);
            }

            // Call this to reset the bar
            public void ResetProgress()
            {
                SetProgress(0f);
            }
        }
}
