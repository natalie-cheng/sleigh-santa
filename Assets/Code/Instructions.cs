using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    // track page
    private float page;

    // track page screen
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    // prefabs
    public GameObject santaPrefab;
    public GameObject sleighPrefab;

    // call start
    private void Start()
    {
        page = 1;
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    // menu button
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // switch to next page
    public void Next()
    {
        page++;
        SwitchPage();
    }

    // switch back a page
    public void Back()
    {
        page--;
        SwitchPage();
    }

    // trigger the relevant page
    private void SwitchPage()
    {
        if (page == 1)
        {
            Page1();
        }
        else if (page == 2)
        {
            Page2();
        }
        else if (page == 3)
        {
            Page3();
        }
    }

    // page 1
    private void Page1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

        GameObject santa = GameObject.FindWithTag("Santa");
        if (santa != null)
        {
            Destroy(santa);
        }

        GameObject sleigh = GameObject.FindWithTag("Sleigh");
        if (sleigh != null)
        {
            Destroy(sleigh);
        }
    }

    // page 2
    private void Page2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);

        Vector2 position = new Vector2(-2f, 1.5f);
        if (GameObject.FindWithTag("Santa") == null)
        {
            GameObject santa = Instantiate(santaPrefab, position, Quaternion.identity);
        }

        position = new Vector2(-2f, -0.75f);
        if (GameObject.FindWithTag("Sleigh") == null)
        {
            GameObject sleigh = Instantiate(sleighPrefab, position, Quaternion.identity);
        }
    }

    // page 3
    private void Page3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);

        GameObject sleigh = GameObject.FindWithTag("Sleigh");
        if (sleigh != null)
        {
            Destroy(sleigh);
        }
    }
}
