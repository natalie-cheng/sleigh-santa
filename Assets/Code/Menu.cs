using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // start button
    public void Play()
    {
        // clear gifts
        Utilities.gifts = new List<GameObject>();
        SceneManager.LoadScene("Main");
    }

    // instructions button
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    // quit button
    public void Quit()
    {
        Application.Quit();
    }
}
