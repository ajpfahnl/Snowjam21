using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button bgm, sfx;
    [SerializeField] Sprite[] images; //set in inspector

    [Header("How To Play Panels")]
    [SerializeField] GameObject[] panel;
    int pageNum = 0;

    [Header("Scenes")]
    [SerializeField] string menu = "StartScreen", game = "SampleScene";

    /*[Header("Audio")]
    [SerializeField] AudioSource music;
    [SerializeField] Audio*/

    //[SerializeField] SoundManager soundManager;
    private bool bgmOn = true;
    private bool sfxOn = true;

    private void Update()
    {
        if (bgmOn)
        {
            bgm.image.sprite = images[0]; //set bgm icon to be on
        }
        else
        {
            bgm.image.sprite = images[1]; //set bgm icon to be off
        }

        if (sfxOn)
        {
            sfx.image.sprite = images[2]; //set sfx icon to be on
        }
        else
        {
            sfx.image.sprite = images[3]; //set sfx icon to be off
        }

        //swap between panels in how to play
        if(pageNum == 0)
        {
            panel[0].SetActive(true);
            panel[1].SetActive(false);
        } else if(pageNum == 1)
        {
            panel[0].SetActive(false);
            panel[1].SetActive(true);
        }

        /*
        soundManager.SetBGM(bgmOn);
        soundManager.SetSFX(sfxOn);
         */
    }

    //buttons
    public void Menu()
    {
        howToPlay.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }


    public void Next()
    {
        pageNum ++;
        Debug.Log(pageNum);
    }

    public void Back(){
        pageNum --;
        Debug.Log(pageNum);
    }

    //toggles
    public void ToggleBGM() //toggle when clicked on
    {
        bgmOn = !bgmOn;
        Debug.Log(bgmOn);
    }

    public void ToggleSFX()
    {
        sfxOn = !sfxOn;
        Debug.Log(sfxOn);
    }


    //SCENE MANAGEMENT
    public void QuitToMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(game);
    }

}
