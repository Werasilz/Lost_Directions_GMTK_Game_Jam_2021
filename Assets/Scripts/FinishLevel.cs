using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameManager gameManager;

    public bool FinishMission;

    public Unit setCollectAllItem;

    public CheckColor finalColor;

    private MeshRenderer finalMeshRenderer;

    private float PosY;

    private void Awake()
    {
        finalMeshRenderer = transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
    }

    void Start()
    {
        setLinkShape();
        ChangeFinalColor();

        PosY = gameObject.transform.eulerAngles.y;
    }

    public void setLinkShape()
    {
        if (setCollectAllItem.N)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (setCollectAllItem.S)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (setCollectAllItem.W)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (setCollectAllItem.E)
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
        if (setCollectAllItem.NW)
        {
            transform.GetChild(5).gameObject.SetActive(true);
        }
        if (setCollectAllItem.NE)
        {
            transform.GetChild(6).gameObject.SetActive(true);
        }
        if (setCollectAllItem.SW)
        {
            transform.GetChild(7).gameObject.SetActive(true);
        }
        if (setCollectAllItem.SE)
        {
            transform.GetChild(8).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (FinishMission)
        {
            //gameObject.GetComponent<Collider>().enabled = false;
            FinishMission = false;
            gameManager.LevelNow += 1;
            gameManager.levelText.text = "Level : " + gameManager.LevelNow.ToString();
            gameManager.Player.transform.position = gameManager.LevelPosition[gameManager.LevelNow - 1].position;
            gameManager.Player.transform.rotation = gameManager.LevelPosition[gameManager.LevelNow - 1].rotation;
        }
    }

    public void checkMission(GameObject player)
    {
        if (!FinishMission)
        {
            if (player.transform.eulerAngles.y >= PosY - 5f && player.transform.eulerAngles.y <= PosY + 5f)
            {
                if (setCollectAllItem.N == player.GetComponent<PlayerController>().unitCollect[0].N)
                {
                    if (setCollectAllItem.S == player.GetComponent<PlayerController>().unitCollect[0].S)
                    {
                        if (setCollectAllItem.E == player.GetComponent<PlayerController>().unitCollect[0].E)
                        {
                            if (setCollectAllItem.W == player.GetComponent<PlayerController>().unitCollect[0].W)
                            {
                                if (setCollectAllItem.NW == player.GetComponent<PlayerController>().unitCollect[0].NW)
                                {
                                    if (setCollectAllItem.NE == player.GetComponent<PlayerController>().unitCollect[0].NE)
                                    {
                                        if (setCollectAllItem.SW == player.GetComponent<PlayerController>().unitCollect[0].SW)
                                        {
                                            if (setCollectAllItem.SE == player.GetComponent<PlayerController>().unitCollect[0].SE)
                                            {
                                                if (finalColor.Red == player.GetComponent<PlayerController>().playerColor.Red)
                                                {
                                                    if (finalColor.Blue == player.GetComponent<PlayerController>().playerColor.Blue)
                                                    {
                                                        if (finalColor.Green == player.GetComponent<PlayerController>().playerColor.Green)
                                                        {
                                                            if (finalColor.Yellow == player.GetComponent<PlayerController>().playerColor.Yellow)
                                                            {
                                                                FinishMission = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void ChangeFinalColor()
    {
        if (finalColor.Red)
        {
            finalMeshRenderer.material = gameManager.playerMaterial[0];
        }
        if (finalColor.Green)
        {
            finalMeshRenderer.material = gameManager.playerMaterial[1];
        }
        if (finalColor.Blue)
        {
            finalMeshRenderer.material = gameManager.playerMaterial[2];
        }
        if (finalColor.Yellow)
        {
            finalMeshRenderer.material = gameManager.playerMaterial[3];
        }
    }
}
