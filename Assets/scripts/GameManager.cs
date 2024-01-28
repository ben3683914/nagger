using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SpinManager SpinManager;
    public CameraManager CameraManager;
    public GuessManager GuessManager;

    private void Awake()
    {
        Instance = this;
    }
}
