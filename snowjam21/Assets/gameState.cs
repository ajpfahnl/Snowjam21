using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour
{
    public static gameState gameStateScr;
    public static bool started;
    public static bool lost;

    public GameObject startText;
    public GameObject loseText;

    private void Awake()
    {
        gameStateScr = GetComponent<gameState>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            started = false;
            lost = false;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public static void doStart()
    {
        gameStateScr.startText.SetActive(false);
        started = true;
    }
    public static void doLose()
    {
        gameStateScr.loseText.SetActive(true);
        lost = true;
    }
}
