using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    private bool pauseGame = false;
    public AudioSource Song;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        GameOverScreen.SetActive(true);
        //ToggleTime(); //This is so it stops the time/gameplay when you die
    }

    public void ToggleTime(){
        pauseGame = !pauseGame;

        if(pauseGame){Time.timeScale = 0;}
        else {Time.timeScale = 1;}
    }

    public void Restart(){
       // ToggleTime();
        //SceneManager.LoadScene(0); //This would be to set it to the first scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        //ToggleTime();
        SceneManager.LoadScene(0);
    }

}
