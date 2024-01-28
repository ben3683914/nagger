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
        Board = 1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if(Camera.main == cameras[(int)Cams.Spinner])
            {
                GameManager.Instance.GameState.ChangeState(new BoardState());
                return;
            }

            GameManager.Instance.GameState.ChangeState(new SpinnerState());
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

    void SetSpinnerCamera()
    {
        SetCamera(Cams.Spinner);
    }

    void SetBoardCamera()
    {
        SetCamera(Cams.Board);
    }
}
