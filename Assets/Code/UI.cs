using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // total timer time
    private float totalTime = 181f;
    // track current time
    private float currentTime;

    // UI objects
    public TextMeshProUGUI timerText;
    public GameObject pauseScreen;
    public GameObject helpScreen;
    public GameObject gameOverScreen;

    // number of houses
    private float numHouses = 12;

    // game over
    public TextMeshProUGUI gameOverText;
    private string winText = "Yay!  Santa delivered all his gifts!";
    private string lossText = "Oh no... Santa didn't deliver his gifts on time :(";
    public static bool gameOver;

    // call start
    private void Start()
    {
        // set the time
        currentTime = totalTime;

        // disable UI screens
        pauseScreen.SetActive(false);
        helpScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        // game is not over
        gameOver = false;
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

        // if time is up
        if (currentTime <= 1f)
        {
            // game lose
            SetGameOverInternal(false);
        }

        // if all the houses are gifted
        if (Utilities.gifts.Count == numHouses)
        {
            // game win
            SetGameOverInternal(true);
        }

        // calculate time
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // display time
        timerText.text = "Time: " + (minutes > 0 ? minutes.ToString() : "0") + ":" + (seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString());

    }

    // set game over
    private void SetGameOverInternal(bool win)
    {
        gameOver = true;
        if (win)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            gameOverText.text = winText;
        }
        else
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            gameOverText.text = lossText;
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
