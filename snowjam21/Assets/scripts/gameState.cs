using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour
{

    public AudioSource music;
    public static gameState gameStateScr;
    public static bool started;
    public static bool lost;

    public GameObject startText;
    public GameObject loseText;

    public ParticleSystem flames;

    private void Awake()
    {
        gameStateScr = GetComponent<gameState>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            restart();
        }
    }

    private void FixedUpdate()
    {
        if (lost)
        {
            if (gameStateScr.music.volume > 0)
            {
                gameStateScr.music.volume -= .02f;
            }
        }
    }

    public static void restart()
    {
        Time.timeScale = 1;
        score.points = 0;
        started = false;
        lost = false;
        SceneManager.LoadScene("SampleScene");
    }

    public static void doStart()
    {
        gameStateScr.startText.SetActive(false);
        started = true;

        gameStateScr.flames.Play();
        gameStateScr.music.Play();

        mapGenerator.spawnChance = 125;
        mapGenerator.elapsedTime = 0;
        mainCam.riseRate = .03f;
    }
    public static void doLose()
    {
        mainCam.addTrauma(70);
        gameStateScr.loseText.SetActive(true);
        lost = true;
        playerMovement.trfm.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
