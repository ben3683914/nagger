using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Camera[] cameras;

    [SerializeField]
    private Canvas[] canvases;

    public enum Cams {
        Spinner = 0,
        Board = 1,
        Fail= 2,
        Success= 3,
        Win = 4
    }

    public Cams _selectedCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            var nextCam = ((int)_selectedCam % 5) + 1;

            GameManager.Instance.GameState.ChangeState(CreateState(nextCam));
        }
    }

    public void SetCamera(Cams cam)
    {
        // there's an assumption that every camera will have a different UI canvas
        foreach(var c in cameras)
        {
            c.gameObject.SetActive(false);
        }

        cameras[(int)cam].gameObject.SetActive(true);
        _selectedCam = cam;
        ChangeCanvas(cam);
    }

    void ChangeCanvas(Cams cam)
    {
        foreach(var canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        canvases[(int)cam].gameObject.SetActive(true);
    }

    public IState CreateState(int stateId)
    {
        switch (stateId)
        {
            case (int)Cams.Spinner: return new SpinnerState();
            case (int)Cams.Board: return new BoardState();
            case (int)Cams.Fail: return new FailState();
            case (int)Cams.Success: return new SuccessState();
            case (int)Cams.Win: return new WinState();
            default: return new SpinnerState();
        }
    }

    void SetSpinnerCamera()
    {
        SetCamera(Cams.Spinner);
    }

    void SetBoardCamera()
    {
        SetCamera(Cams.Board);
    }
}
