using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IState
{
    GameManager gm;

    public void Enter()
    {
        gm = GameManager.Instance;
        Debug.Log("entered win state");
        gm.CameraManager.SetCamera(CameraManager.Cams.Win);

    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
