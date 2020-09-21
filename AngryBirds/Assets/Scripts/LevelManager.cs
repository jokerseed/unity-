using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject map;

    private AudioSource au;

    private void Awake()
    {
        au = GetComponent<AudioSource>();
    }

    private void Start()
    {
        au.Play();
    }

    public void TestDefaultLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void GoHome()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        map.SetActive(true);
    }
}
