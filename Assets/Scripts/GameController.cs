using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public enum GameState
{
    Running,
    Paused,
    BeforeFinish,
    Finished
}

public class GameController : MonoBehaviour
{
    static public GameState gameState { get; set; }
    public RawImage FinishMsgBox;
    public AudioSource FinishSound;
    public RawImage PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Running;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.gameObject.SetActive(!PauseMenu.gameObject.activeSelf);
            if (PauseMenu.gameObject.activeSelf)
            {
                gameState = GameState.Paused;
            }
            else
            {
                gameState = GameState.Running;
            }
        }

        if(gameState == GameState.BeforeFinish)
        {
            FinishMsgBox.gameObject.SetActive(true);
            FinishSound.Play();
            gameState = GameState.Finished;
        }
    }

    public void GotoNextLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Continue()
    {
        PauseMenu.gameObject.SetActive(false);
        gameState = GameState.Running;
    }
}
