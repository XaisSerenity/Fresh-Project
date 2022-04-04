using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int targetValue;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            AddToScore();
            ScoreUpdate();
        }
    }
    public virtual void AddToScore()
    {
        gameManager.AddToScore(targetValue);
    }
    public void ScoreUpdate()
    {
        scoreText.SetText("score: " + gameManager.currentScore);
    }
}
