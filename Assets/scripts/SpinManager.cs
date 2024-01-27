using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour
{
    public GameObject spinner;
    public Button button;

    float rotSpeed = 2f;
    float[]durationRange = {1.5f, 5f};
    float duration;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Spin()
    {
        Debug.Log("spinning");

        duration = Random.Range(durationRange[0], durationRange[1]);
        Debug.Log($"duration: {duration}");
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

        button.interactable = true;

        yield return null;
    }
}
