using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Simple Main Menu Created New Scene and put this at top of build settings above game scene
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // PlayGame button goes into game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    // Quits Game completely does nothing in unity
    public void ExitGame()
    {
        Application.Quit();
    }
}
