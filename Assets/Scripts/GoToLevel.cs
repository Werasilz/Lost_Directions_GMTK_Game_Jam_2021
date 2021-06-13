using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLevel : MonoBehaviour
{
    public GameManager gameManager;
    public int levelTarget;

    void OnMouseDown()
    {
        if (gameManager.isShowSelect)
        {
            Debug.Log(levelTarget);
            gameManager.LevelNow = this.levelTarget;
            gameManager.levelText.text = "Level : " + gameManager.LevelNow.ToString();
            gameManager.Player.transform.position = gameManager.LevelPosition[this.levelTarget - 1].position;
            gameManager.Player.transform.rotation = gameManager.LevelPosition[this.levelTarget - 1].rotation;
            GameObject.Find("Player").GetComponent<PlayerController>().SetStartArrow();
            gameManager.CamHide();
        }
    }
}
