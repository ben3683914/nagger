using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpinManager SpinManager;

    private void Start()
    {
        SpinManager = GetComponentInChildren<SpinManager>();
    }
}
