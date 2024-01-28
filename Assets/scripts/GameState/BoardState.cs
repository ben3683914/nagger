using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : IState
{
    GuessManager guessManager;
    LadderManager ladderManager;
    public void Enter()
    {
        Debug.Log("entered board state");
        GameManager.Instance.CameraManager.SetCamera(CameraManager.Cams.Board);

        guessManager = GameManager.Instance.GuessManager;
        ladderManager = GameManager.Instance.LadderManager;

        guessManager.StartPhrase(ladderManager.CurrentTier);
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
