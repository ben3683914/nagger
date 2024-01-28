using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessState : IState
{
    GameManager gm;

    public void Enter()
    {
        gm = GameManager.Instance;
        Debug.Log("entered success state");
        gm.CameraManager.SetCamera(CameraManager.Cams.Success);

    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
