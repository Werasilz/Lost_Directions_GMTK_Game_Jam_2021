using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed;
    public Unit[] unitCollect;
    public GameObject particle;

    private MeshRenderer playerMesh;

    public CheckColor playerColor;

    void Start()
    {
        playerMesh = GameObject.Find("MainCenter").GetComponent<MeshRenderer>();
        playerMesh.material = gameManager.playerMaterial[0];
    }

    void Update()
    {
        ShowUnit();
        ResetPosition();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void ShowUnit()
    {
        transform.GetChild(0).gameObject.SetActive(unitCollect[0].N);
        transform.GetChild(1).gameObject.SetActive(unitCollect[0].S);
        transform.GetChild(2).gameObject.SetActive(unitCollect[0].W);
        transform.GetChild(3).gameObject.SetActive(unitCollect[0].E);
        transform.GetChild(4).gameObject.SetActive(unitCollect[0].NW);
        transform.GetChild(5).gameObject.SetActive(unitCollect[0].NE);
        transform.GetChild(6).gameObject.SetActive(unitCollect[0].SW);
        transform.GetChild(7).gameObject.SetActive(unitCollect[0].SE);
    }

    void Movement()
    {
        if (!gameManager.isShowSelect)
        {
            if (Input.GetKey(KeyCode.UpArrow) && unitCollect[0].N)
            {
                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && unitCollect[0].S)
            {
                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && unitCollect[0].W)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && unitCollect[0].E)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && unitCollect[0].NE)
            {
                transform.Translate(Vector3.forward * moveSpeed / 2 * Time.deltaTime);
                transform.Translate(Vector3.right * moveSpeed / 2 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && unitCollect[0].NW)
            {
                transform.Translate(Vector3.forward * moveSpeed / 2 * Time.deltaTime);
                transform.Translate(Vector3.left * moveSpeed / 2 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && unitCollect[0].SE)
            {
                transform.Translate(Vector3.back * moveSpeed / 2 * Time.deltaTime);
                transform.Translate(Vector3.right * moveSpeed / 2 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && unitCollect[0].SW)
            {
                transform.Translate(Vector3.back * moveSpeed / 2 * Time.deltaTime);
                transform.Translate(Vector3.left * moveSpeed / 2 * Time.deltaTime);
            }
        }
    }

    void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameManager.LevelNow > 0)
        {
            gameObject.transform.position = gameManager.LevelPosition[gameManager.LevelNow - 1].position;
            gameObject.transform.rotation = gameManager.LevelPosition[gameManager.LevelNow - 1].rotation;

            gameManager.SetActiveAllItem(true);

            SetStartArrow();
            particle.GetComponent<ParticleSystem>().Play();

            AudioManager audioManager;
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound(audioManager.sfx[2]);
        }
    }

    public void SetStartArrow()
    {
        unitCollect[0].N = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.N;
        unitCollect[0].S = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.S;
        unitCollect[0].E = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.E;
        unitCollect[0].W = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.W;
        unitCollect[0].NW = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.NW;
        unitCollect[0].NE = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.NE;
        unitCollect[0].SW = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.SW;
        unitCollect[0].SE = gameManager.LevelPosition[gameManager.LevelNow - 1].gameObject.GetComponent<StartArrow>().startArrow.SE;
    }

    private void OnTriggerEnter(Collider other)
    {
        // take item
        if (other.gameObject.CompareTag("Item"))
        {
            if (other.gameObject.GetComponent<ItemAddArrow>().N)
            {
                unitCollect[0].N = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().S)
            {
                unitCollect[0].S = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().W)
            {
                unitCollect[0].W = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().E)
            {
                unitCollect[0].E = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().NW)
            {
                unitCollect[0].NW = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().NE)
            {
                unitCollect[0].NE = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().SW)
            {
                unitCollect[0].SW = true;
            }
            if (other.gameObject.GetComponent<ItemAddArrow>().SE)
            {
                unitCollect[0].SE = true;
            }

            other.gameObject.SetActive(false);

            AudioManager audioManager;
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound(audioManager.sfx[1]);
        }

        if (other.gameObject.CompareTag("ChangeColor"))
        {
            if (other.gameObject.GetComponent<ChangeColorPlatform>().setColorPlatform.Red)
            {
                SetNewColor("red");
            }
            if (other.gameObject.GetComponent<ChangeColorPlatform>().setColorPlatform.Green)
            {
                SetNewColor("green");
            }
            if (other.gameObject.GetComponent<ChangeColorPlatform>().setColorPlatform.Blue)
            {
                SetNewColor("blue");
            }
            if (other.gameObject.GetComponent<ChangeColorPlatform>().setColorPlatform.Yellow)
            {
                SetNewColor("yellow");
            }
            ChangePlayerColor();

            AudioManager audioManager;
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound(audioManager.sfx[1]);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLevel"))
        {
            other.gameObject.GetComponent<FinishLevel>().checkMission(gameObject);

            AudioManager audioManager;
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound(audioManager.sfx[0]);
        }

        if (other.gameObject.CompareTag("StartMenu"))
        {
            gameManager.LevelNow = 1;
            SetStartArrow();
            gameManager.levelText.text = "Level : " + gameManager.LevelNow.ToString();
            gameManager.Player.transform.position = gameManager.LevelPosition[gameManager.LevelNow - 1].position;
            gameManager.Player.transform.rotation = gameManager.LevelPosition[gameManager.LevelNow - 1].rotation;

            AudioManager audioManager;
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound(audioManager.sfx[0]);
        }
    }

    void ChangePlayerColor()
    {
        if (playerColor.Red)
        {
            playerMesh.material = gameManager.playerMaterial[0];
        }
        if (playerColor.Green)
        {
            playerMesh.material = gameManager.playerMaterial[1];
        }
        if (playerColor.Blue)
        {
            playerMesh.material = gameManager.playerMaterial[2];
        }
        if (playerColor.Yellow)
        {
            playerMesh.material = gameManager.playerMaterial[3];
        }
    }

    void SetNewColor(string color)
    {
        if (color == "Red" || color == "red")
        {
            playerColor.Red = true;
            playerColor.Green = false;
            playerColor.Blue = false;
            playerColor.Yellow = false;
        }
        if (color == "Green" || color == "green")
        {
            playerColor.Red = false;
            playerColor.Green = true;
            playerColor.Blue = false;
            playerColor.Yellow = false;
        }
        if (color == "Blue" || color == "blue")
        {
            playerColor.Red = false;
            playerColor.Green = false;
            playerColor.Blue = true;
            playerColor.Yellow = false;
        }
        if (color == "Yellow" || color == "yellow")
        {
            playerColor.Red = false;
            playerColor.Green = false;
            playerColor.Blue = false;
            playerColor.Yellow = true;
        }
    }
}

[System.Serializable]
public class Unit
{
    public bool N;
    public bool S;
    public bool W;
    public bool E;
    public bool NW;
    public bool NE;
    public bool SW;
    public bool SE;
}



