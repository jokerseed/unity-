using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
        SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
