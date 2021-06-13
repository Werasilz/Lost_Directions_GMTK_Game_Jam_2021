using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoving : MonoBehaviour
{
    private GameObject Block;
    private Transform startPosition, endPosition;
    public float startDelay,stopTime,speed;
    private bool isStart,onStartPos;
    void Awake()
    {
        Block = transform.GetChild(0).gameObject;
        startPosition = transform.GetChild(1).GetComponent<Transform>();
        endPosition = transform.GetChild(2).GetComponent<Transform>();
    }

    void Start()
    {
        Invoke(nameof(setStartTime), startDelay);
    }

    void Update()
    {
        if(isStart)
        {

        }
    }

    void setStartTime()
    {
        isStart = true;
    }
}
