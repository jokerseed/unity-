using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject btn;

    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void PauseAniEnd()
    {
        Time.timeScale = 0;
    }

    private void ResumeAniEnd()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        ani.SetBool("isPause", true);
        btn.SetActive(false);
    }

    public void Resume()
    {

        Time.timeScale = 1;
        ani.SetBool("isPause", false);
        btn.SetActive(true);
    }
}
