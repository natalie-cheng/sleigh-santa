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

    // grinch spawning pg3
    private float delay = 3;
    private bool spawning;

    // call start
    private void Start()
    {
        // set to first page
        page = 1;
        // enable/disable pages
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        // grinch spawning
        spawning = false;
    }

    // frame update
    private void Update()
    {
        // if it's the grinch page and not already spawning
        if (page == 3 && !spawning)
        {
            // and if a grinch doesn't already exist
            if (GameObject.FindWithTag("Grinch") == null)
            {
                // spawn a grinch
                StartCoroutine(SpawnGrinch());
            }
        }
    }

    // grinch spawning coroutine
    private IEnumerator SpawnGrinch()
    {
        // set spawning to true
        spawning = true;
        // wait for the delay
        yield return new WaitForSeconds(delay);

        // spawn grinch
        if (page == 3)
        {
            Vector2 position = new Vector2(-2f, -1.25f);
            Instantiate(grinchPrefab, position, Quaternion.identity);
        }

        // not spawning anymore
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
        // activate/deactivate pages
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

        // destroy santa if necessary
        GameObject santa = GameObject.FindWithTag("Santa");
        if (santa != null)
        {
            Destroy(santa);
        }

        // destroy sleigh if necessary
        GameObject sleigh = GameObject.FindWithTag("Sleigh");
        if (sleigh != null)
        {
            Destroy(sleigh);
        }
    }

    // page 2
    private void Page2()
    {
        // activate/deactivate pages
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);

        // create/move santa
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

        // create sleigh
        position = new Vector2(-2f, -0.75f);
        if (GameObject.FindWithTag("Sleigh") == null)
        {
            Instantiate(sleighPrefab, position, Quaternion.identity);
        }

        // create grinch
        GameObject grinch = GameObject.FindWithTag("Grinch");
        if (grinch != null)
        {
            Destroy(grinch);
        }
    }

    // page 3
    private void Page3()
    {
        // activate/deactivate pages
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);

        // destroy sleigh if necessary
        GameObject sleigh = GameObject.FindWithTag("Sleigh");
        if (sleigh != null)
        {
            Destroy(sleigh);
        }        

        // reposiiton santa
        Vector2 position = new Vector2(-2f, 1.5f);
        GameObject santa = GameObject.FindWithTag("Santa");
        santa.transform.position = position;

        // create grinch
        position = new Vector2(-2f, -1.25f);
        Instantiate(grinchPrefab, position, Quaternion.identity);
    }
}
