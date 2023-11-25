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
    public GameObject grinchPrefab;

    private float delay = 3;
    private bool spawning;

    // call start
    private void Start()
    {
        page = 1;
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        spawning = false;
    }

    private void Update()
    {
        if (page == 3 && !spawning)
        {
            if (GameObject.FindWithTag("Grinch") == null)
            {
                StartCoroutine(SpawnGrinch());
            }
        }
    }

    private IEnumerator SpawnGrinch()
    {
        spawning = true;
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // spawn grinch
        if (page == 3)
        {
            Vector2 position = new Vector2(-2f, -1.25f);
            Instantiate(grinchPrefab, position, Quaternion.identity);
        }

        spawning = false;
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
        GameObject santa = GameObject.FindWithTag("Santa");
        if (santa == null)
        {
            Instantiate(santaPrefab, position, Quaternion.identity);
        }
        else
        {
            santa.transform.position = position;
        }

        position = new Vector2(-2f, -0.75f);
        if (GameObject.FindWithTag("Sleigh") == null)
        {
            Instantiate(sleighPrefab, position, Quaternion.identity);
        }

        GameObject grinch = GameObject.FindWithTag("Grinch");
        if (grinch != null)
        {
            Destroy(grinch);
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

        Vector2 position = new Vector2(-2f, 1.5f);
        GameObject santa = GameObject.FindWithTag("Santa");
        santa.transform.position = position;

        position = new Vector2(-2f, -1.25f);
        Instantiate(grinchPrefab, position, Quaternion.identity);
    }
}
