using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BoxPopUp : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(BoxPopUpCoroutine());
    }
    private IEnumerator BoxPopUpCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.2f;
        float duration = 0.2f;
        float elapsed = 0f;

        // Scale up
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        yield return new WaitForSeconds(0.1f);
        // Scale down
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
