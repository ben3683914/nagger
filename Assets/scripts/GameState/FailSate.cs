using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : IState
{
    GameManager gm;

    public void Enter()
    {
        gm = GameManager.Instance;
        Debug.Log("entered fail state");
        gm.CameraManager.SetCamera(CameraManager.Cams.Fail);
        
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
