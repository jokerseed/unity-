using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public int starNum = 0;
    public GameObject hasLock;
    public GameObject notLock;
    public GameObject panel;

    private Button btn;
    private bool isSel = false;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        btn.onClick.AddListener(ClickHandle);

        int total = PlayerPrefs.GetInt("totalNum", 0);
        if (total >= starNum)
        {
            isSel = true;
            //已经解锁
            hasLock.SetActive(false);
            notLock.SetActive(true);
            notLock.transform.Find("Text").gameObject.GetComponent<Text>().text = "0";
        }
        else
        {
            //未解锁
            hasLock.SetActive(true);
            notLock.SetActive(false);
            hasLock.transform.Find("Text").gameObject.GetComponent<Text>().text = starNum.ToString();
        }
    }

    public void ClickHandle()
    {
        if (isSel)
        {
            panel.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
