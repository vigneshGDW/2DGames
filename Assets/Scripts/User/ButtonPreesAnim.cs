using System.Collections;
using UnityEngine;

public class ButtonPreesAnim : MonoBehaviour
{
    public bool ispreessanim = false;
    public float reducevalue;
    public void ButtonpreeFun(GameObject Preeobj)
    {
        if(ispreessanim) return;
        ispreessanim = true;
        StartCoroutine(ButtonPressAnim(Preeobj));
    }
    private IEnumerator ButtonPressAnim(GameObject pressobj)
    {
        //ispreessanim = true;
        Vector3 originalScale = pressobj.transform.localScale;
        Vector3 pressedScale = originalScale * reducevalue;
        float animationDuration = 0.1f;
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            pressobj.transform.localScale = Vector3.Lerp(originalScale, pressedScale, (elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        pressobj.transform.localScale = pressedScale;
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            pressobj.transform.localScale = Vector3.Lerp(pressedScale, originalScale, (elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        pressobj.transform.localScale = originalScale;
        ispreessanim = false;
    }
}
