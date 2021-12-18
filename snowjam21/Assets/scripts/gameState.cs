using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

        leaderboard();
    }

    public static void restart()
    {
        Time.timeScale = 1;
        score.points = 0;
        started = false;
        lost = false;
        SceneManager.LoadScene("The Toaster");
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


    //https://docs.google.com/forms/u/0/d/e/1FAIpQLSelEg_SnhtiLRdnfFY3vYwQ_qcZ-lAdLPHGHGM6f3c23kbU0A/formResponse
    //name: entry.1752694714
    //score: entry.1050400351



    bool activate;
    bool sent;
    bool downloaded;
    string url;
    string name;
    public GameObject inputField;
    public WWW download;
    string urlDownload;

    private void Start()
    {
        urlDownload = "https://docs.google.com/spreadsheets/d/1L_eIhFNPj2CpCkoP2u9bJ47j-bZptcsOvKJuDXT8XC4/export?format=csv";
        url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSelEg_SnhtiLRdnfFY3vYwQ_qcZ-lAdLPHGHGM6f3c23kbU0A/formResponse";
    }

    void leaderboard()
    {
        if (lost)
        {
            if (!activate)
            {
                activate = true;
                //inputField.SetActive(true);
            }
            if (!sent && Input.GetKey(KeyCode.Return) && inputField.GetComponent<TMP_InputField>().text != "")
            {
                StartCoroutine(Post());
                sent = true;
            }
        }
        /*
        if (Input.GetKey(KeyCode.Return) && !sent && inputField.GetComponent<InputField>().text != "")
        {
            inputField.SetActive(false);
            sent = true;
        }
        if (dead > 75 && dead < 95)
        {
            scorePos[0].localScale += new Vector3(0.07f, 0.1f, 0);
            scorePos[0].localPosition += new Vector3(0, .9f, 0);
        }
        if (download.isDone && !downloaded)
        {
            tabToReset.SetActive(true);
            arKeyPan.SetActive(true);
            downloaded = true;
            rows = download.text.Split(',');
            //values = rows;
            for (int i = 0; i < 999; i++)
            {
                if (5 + 3 * i > rows.Length - 1) { break; }
                tmPro.text += rows[4 + 3 * i] + "\n";
                tmPro0.text += rows[5 + 3 * i] + "\n";
            }
        }
        */
    }

    IEnumerator Post()
    {
        
        WWWForm form = new WWWForm();
        form.AddField("entry.1752694714", "thank fkin god");
        form.AddField("entry.1050400351", 183.ToString());
        byte[] rawData = form.data;
        WWW www = new WWW(url, rawData); yield return www;

        WWWForm form0 = new WWWForm();
        download = new WWW(urlDownload, form0);
    }

}
