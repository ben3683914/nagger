using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerState : IState
{

    public void Enter()
    {
        Debug.Log("entered spinner state");
        GameManager.Instance.CameraManager.SetCamera(CameraManager.Cams.Spinner);
    }

    public void Execute()
    {
        Debug.Log("executing spinner state");
    }

    public void Exit()
    {
        Debug.Log("exiting spinner state");
    }
}
