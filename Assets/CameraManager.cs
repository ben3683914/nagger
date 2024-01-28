using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;
    public Canvas[] canvases;

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
                SetBoardCamera();
                return;
            }

            SetSpinnerCamera();
        }
    }

    public void ChangeCamera(Cams cam)
    {
        foreach(var c in cameras)
        {
            c.gameObject.SetActive(false);
        }

        cameras[(int)cam].gameObject.SetActive(true);
        ChangeCanvas(cam);
    }

    public void ChangeCanvas(Cams cam)
    {
        foreach(var canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        canvases[(int)cam].gameObject.SetActive(true);
    }

    public void SetSpinnerCamera()
    {
        ChangeCamera(Cams.Spinner);
    }

    public void SetBoardCamera()
    {
        ChangeCamera(Cams.Board);
    }
}