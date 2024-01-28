using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour
{
    public UnityEvent<int> OnNeedleHit;
    public GameObject spinner;
    public Button spinButton;
    public Button nsfwButton;
    public Needle needle;
    public Sprite nsfwNeedle;
    public Sprite sfwNeedle;


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

    public void Interactable(bool toggle = true)
    {
        spinButton.interactable = toggle;
    }

    public void MakeNSFW()
    {
        if (GameManager.Instance.NSFW)
        {
            GameManager.Instance.NSFW = false;
            needle.GetComponentInChildren<SpriteRenderer>().sprite = sfwNeedle;
        }
        else
        {
            GameManager.Instance.NSFW = true;
            needle.GetComponentInChildren<SpriteRenderer>().sprite = nsfwNeedle;
        }
        
    }

    IEnumerator Spin(float duration)
    {
        spinButton.interactable = false;
        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;
            spinner.transform.Rotate(0,0, rotSpeed);
            yield return null;
        }

        NeedleCheck();

        yield return null;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.GameState.ChangeState(new BoardState());
    }

    public int NeedleCheck()
    {
        var hints = needle.GetNeedleHints();
        OnNeedleHit.Invoke(hints);
        StartCoroutine(Wait());
        return hints;
    }
}
