using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Phaygame : MonoBehaviour
{
    public GameObject Playgame,  voice1, voice2, exit, pause, continuegame, exitgame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BatDau()
    {
        SceneManager.LoadScene("Man_1");
        Time.timeScale = 1;
    }
    public void setTing()
    {
        Playgame.SetActive(false);
        voice1.SetActive(true);
        voice2.SetActive(true);
        exit.SetActive(true);
    }
    public void exitTing()
    {
        Playgame.SetActive(true);
        voice1.SetActive(false);
        voice2.SetActive(false);
        exit.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        continuegame.SetActive(true);
        exitgame.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        continuegame.SetActive(false);
        exitgame.SetActive(false);
    }
  
}
