using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Sprite sp;

    private bool canSelect = false;
    private Image bg;
    private Button btn;

    private void Awake()
    {
        bg = GetComponent<Image>();
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        if (transform.parent.GetChild(0).gameObject.name == gameObject.name)
        {
            canSelect = true;
            bg.overrideSprite = sp;
            transform.Find("Text").gameObject.SetActive(true);
            btn.onClick.AddListener(Select);
        }
    }

    public void Select() {
        SceneManager.LoadScene(2);
    }
}
