using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public GameObject win;
    public GameObject lose;
    public GameObject[] stars;

    public static GameManager _instance;

    private Vector3 curPos;

    private void Awake()
    {
        _instance = this;
        curPos = birds[0].gameObject.transform.position;
    }

    private void Start()
    {
        Initialized();
        win.SetActive(false);
        lose.SetActive(false);
    }

    void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = curPos;
                birds[i].enabled = true;
                birds[i].sj.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sj.enabled = false;
            }
        }
    }

    public void CheckWin()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                Initialized();
            }
            else
            {
                //失败
                Debug.Log("失败");
                showLose();
            }
        }
        else
        {
            //胜利
            Debug.Log("胜利");
            showWin();
        }
    }

    void showWin() {
        win.SetActive(true);
        ShowStars();
    }

    void showLose() {
        lose.SetActive(true);
    }

    void ShowStars() { 
        if (birds.Count >= 2) {
            //3 star
            StartCoroutine("Star", 3);
        } else if (birds.Count >= 1) {
            //2 satr
            StartCoroutine("Star", 2);
        }
        else {
            //1 star
            StartCoroutine("Star", 1);
        }
    }

    IEnumerator Star(int num)
    {
        for (int i = 0; i < num; i++)
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        SceneManager.LoadScene(1);
    }
}
