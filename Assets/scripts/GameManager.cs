using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SpinManager SpinManager;
    public CameraManager CameraManager;
    public GuessManager GuessManager;
    public LadderManager LadderManager;
    public GameState GameState;
    public SpriteManager SpriteManager;
    public bool NSFW;

    private void Awake()
    {
        Instance = this;
        NSFW = false;
        GameState = new GameState();
        GameState.ChangeState(new SpinnerState());
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

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Continue()
    {
        LadderManager.NextPhrase();
    }
}
