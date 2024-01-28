using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class win : MonoBehaviour
{
    public TMP_Text text;
    private void Awake()
    {
        if (GameManager.Instance.NSFW)
        {
            text.text = "Congratulations! \r\nYou're a real nagger!";
        }
    }
}
