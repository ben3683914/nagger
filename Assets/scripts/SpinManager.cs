using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour
{
    public UnityEvent<int> OnNeedleHit;
    public GameObject spinner;
    public Button button;
    public Needle needle;

    float rotSpeed = 2f;
    float[] durationRange = {1.5f, 5f};
    float duration;

    public void Spin()
    {
        //Debug.Log("spinning");

        duration = Random.Range(durationRange[0], durationRange[1]);
        //Debug.Log($"duration: {duration}");
        StartCoroutine(Spin(duration));
    }

    IEnumerator Spin(float duration)
    {
        button.interactable = false;
        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;
            spinner.transform.Rotate(0,0, rotSpeed);
            yield return null;
        }

        NeedleCheck();

        button.interactable = true;

        yield return null;
    }

    public int NeedleCheck()
    {
        var hints = needle.GetNeedleHints();
        OnNeedleHit.Invoke(hints);
        return hints;
    }
}
