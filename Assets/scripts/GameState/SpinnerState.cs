using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerState : IState
{
    GameManager gm;
    SpinManager spinManager;

    public void Enter()
    {
        gm = GameManager.Instance;
        spinManager = GameManager.Instance.SpinManager;

        Debug.Log("entered spinner state");
        gm.CameraManager.SetCamera(CameraManager.Cams.Spinner);
        spinManager.Interactable();
    }

    public void Execute()
    {
        //Debug.Log("executing spinner state");
    }

    public void Exit()
    {
        Debug.Log("exiting spinner state");
        spinManager.Interactable(false);
    }
}
