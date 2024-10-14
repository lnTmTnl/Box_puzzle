using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBtns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelectLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
