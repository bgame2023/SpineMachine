using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public void EffectChangeNumber(Action<int> actionSetText,int valueCurr, int newValue, float duration)
    {
        StartCoroutine(ChangeNumberCoroutine(actionSetText, valueCurr, newValue, duration));
    }

    private IEnumerator ChangeNumberCoroutine(Action<int> actionSetText, int valueCurr, int newValue, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            int currentValue = (int)Mathf.Lerp(valueCurr, newValue, elapsedTime / duration);
            actionSetText(currentValue);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        actionSetText(newValue);
    }
}
