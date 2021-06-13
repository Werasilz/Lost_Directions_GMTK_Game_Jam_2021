using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPlatform : MonoBehaviour
{
    public CheckColor setColorPlatform;
    private GameManager gameManager;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {
        if(setColorPlatform.Red)
        {
           meshRenderer.material = gameManager.playerMaterial[0];
        }
        if (setColorPlatform.Green)
        {
            meshRenderer.material = gameManager.playerMaterial[1];
        }
        if (setColorPlatform.Blue)
        {
            meshRenderer.material = gameManager.playerMaterial[2];
        }
        if (setColorPlatform.Yellow)
        {
            meshRenderer.material = gameManager.playerMaterial[3];
        }
    }
}
