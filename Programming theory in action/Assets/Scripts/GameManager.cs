using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<CannonAmmo> cannonAmmoScript = new List<CannonAmmo>();
    public List<GameObject> ammo = new List<GameObject>();
    public int ammoLeft;
    public bool gameOver;
    public int currentScore;

    public TextMeshProUGUI scoreCounter;
    public Button playAgainButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI newBestText;
    public TextMeshProUGUI newTopText;

    public bool projectileExists;
    
    public int projectileDestroyed;

    Cannon cannon;

    private void Awake()
    {
        cannon = GameObject.Find("Cannon").GetComponent<Cannon>();
        
       foreach (CannonAmmo a in cannonAmmoScript)
        {
            ammoLeft ++;
            projectileDestroyed++;
        }
        
        foreach (CannonAmmo a in cannonAmmoScript)
        {
            a.ballAmmo  += ammoLeft;
        }
        
        
    }

    void OnShoot()
    {
       if (ammoLeft > 0)
        {
            cannon.Shoot();
            foreach (CannonAmmo a in cannonAmmoScript)
            {
                a.DestroyAmmo();
            }
            ammoLeft -= 1;
            foreach (CannonAmmo a in cannonAmmoScript)
            {
                a.ballAmmo = ammoLeft;
            }
        }
        
    }
    private void Update()
    {
        GameOver();
    }
    public void AddToScore(int value)
    {
        currentScore += value;
        
    }
    public void ShowEndGameUI()
    {
        playAgainButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }
    public void ScoreCheck()
    {
        if (currentScore > MainManager.Instance.playerHighScore)
        {
            newBestText.gameObject.SetActive(true);
            MainManager.Instance.playerHighScore = currentScore;
            MainManager.Instance.SaveHighScore();
           
        }
        if (currentScore > MainManager.Instance.topScore)
        {

            newTopText.gameObject.SetActive(true);
            MainManager.Instance.topScore = currentScore;
            MainManager.Instance.topScorerName = MainManager.Instance.playerName;
            MainManager.Instance.SaveTopScorer();
            
        }
    }
    public void GameOver()
    {

        if (GameObject.FindGameObjectWithTag("Projectile"))
        {
            projectileExists = true;
        }
        else
        {
            projectileExists = false;
        }
        Debug.Log("Ammo left: " + ammoLeft, this);
        if (projectileDestroyed <= 0)
        {
            gameOver = true;
            ShowEndGameUI();
            ScoreCheck();
            Debug.Log("GAME OVER");
        }
        else
        {
            gameOver = false;
        }
       
    }
}
