using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    public Dictionary<string, Sprite> Sprites;
    public Sprite Nagger;
    public Sprite Maggots;

    private void Awake()
    {
        Sprites = new Dictionary<string, Sprite>();
        Sprites.Add("Nagger", Nagger);
        Sprites.Add("Maggots", Maggots);
    }
}
