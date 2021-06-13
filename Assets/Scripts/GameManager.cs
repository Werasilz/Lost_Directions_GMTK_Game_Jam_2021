using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public Transform[] LevelPosition;
    public int LevelNow;
    public GameObject Player;
    public GameObject[] itemAddArrow;
    public TextMeshProUGUI levelText;
    public CinemachineVirtualCamera cam2;
    public bool isShowSelect;

    /*
    * 0 = red
    * 1 = green
    * 2 = blue
    * 3 = yellow
    */
    public Material[] playerMaterial;


    void Awake()
    {
        itemAddArrow = GameObject.FindGameObjectsWithTag("Item");
        levelText.text = "Level : " + LevelNow.ToString();
    }

    private void Start()
    {
        cam2.gameObject.SetActive(false);
        isShowSelect = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !isShowSelect)
        {
            CamShow();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && isShowSelect)
        {
            CamHide();
        }
    }

    public void SetActiveAllItem(bool set)
    {
        for (int i = 0; i < itemAddArrow.Length; i++)
        {
            itemAddArrow[i].SetActive(set);
        }
    }

    public void CamShow()
    {
        Invoke(nameof(Show), 1);
        cam2.gameObject.SetActive(true);
    }

    public void CamHide()
    {
        Invoke(nameof(Hide), 1);
        cam2.gameObject.SetActive(false);
    }

    void Show()
    {
        isShowSelect = true;
    }

    void Hide()
    {
        isShowSelect = false;
    }

    public void GoToLevel(int target)
    {
        LevelNow = target;
    }
}

[System.Serializable]
public class CheckColor
{
    public bool Red;
    public bool Green;
    public bool Blue;
    public bool Yellow;
}
