using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fail : MonoBehaviour
{
    public TMP_Text text;
    private void Awake()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();

        if (GameManager.Instance.NSFW)
        {
            text.text = "You Failed.\r\nLike a real nagger.";
        }
    }
}
