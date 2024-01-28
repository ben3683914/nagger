using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool NSFW = true;

    public SpinManager SpinManager;
    public CameraManager CameraManager;
    public GuessManager GuessManager;
    public LadderManager LadderManager;
    public GameState GameState;

    private void Awake()
    {
        Instance = this;
        GameState = new GameState();
        GameState.ChangeState(new SpinnerState());
        GameState.ChangeState(new BoardState());
    }

    private void Update()
    {
        GameState.Update();
    }

    public void Win()
    {
        Debug.Log("You Win!");
    }

    public void Fail()
    {
        Debug.Log("Wow you failed, bro! Yo momma hates you!!");
    }
}
