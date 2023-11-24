using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // total timer time
    private float totalTime = 180f;
    // track current time
    private float currentTime;

    // UI objects
    public TextMeshProUGUI timerText;
    public GameObject pauseScreen;
    public GameObject helpScreen;

    // call start
    private void Start()
    {
        // set the time
        currentTime = totalTime;

        // disable UI screens
        pauseScreen.SetActive(false);
        helpScreen.SetActive(false);
    }

    // frame update
    private void Update()
    {
        // check - esc is also pause option
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        // update timer
        currentTime -= Time.deltaTime;

        // calculate time
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // display time
        timerText.text = "Time: " + (minutes > 0 ? minutes.ToString() : "0") + ":" + (seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString());

        // if time is up
        if (currentTime <= 0f)
        {
            // game end
        }
    }

    // pause button/ui
    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    // instructions/help button/ui
    public void Help()
    {
        Time.timeScale = 0;
        helpScreen.SetActive(true);
    }

    // resume button
    public void Resume()
    {
        helpScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // restart button
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // load menu
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
