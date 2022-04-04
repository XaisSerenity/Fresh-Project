using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MainUI : MonoBehaviour
{

    public TMP_InputField inputName;
    public TMP_Text currentHighScorer;
    

    private void Update()
    {
      
      
    }
    private void Start()
    {

        if (GameObject.Find("Title") != null)
        {

            CurrentHighScorer();
            LastPlayerPlayed();
            
        }
       
    }
    public void StartButtonMM()
    {
        MainManager.Instance.playerName = inputName.text;
        MainManager.Instance.lastPlayer = inputName.text;
        MainManager.Instance.SaveLastPlayerPlayed();
        MainManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }
    public void ToStartMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain1()
    {
        SceneManager.LoadScene(1);
    }
    public void LastPlayerPlayed()
    {
       
        MainManager.Instance.LoadLastPlayerPlayed();
        if (MainManager.Instance.lastPlayer != null)
        {
            inputName.text = MainManager.Instance.lastPlayer;
        }
    }
    public void CurrentHighScorer()
    {
        MainManager.Instance.LoadTopScorer();

        if (MainManager.Instance.topScorer != false)
        {

            currentHighScorer.text = MainManager.Instance.topScorerName + " has TOP SCORE of " + MainManager.Instance.topScore;
        }
    }
}
