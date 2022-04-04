using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this Script show inheritance, this class is inheriting from the Taget Class
public class DodgingTarget : Target
{
    //Shows exampls of Encapsulation making some of these variables private so no other script can mess with their values
    
  
    private int juke;
    public float speed;
    private float timer;
    public float movementContainer;
    public int scoreValue;
    private GameManager gManager;

    private void Awake()
    {
        gManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // This is showing PolyMorphism by morphing the parent class's AddToScore() method
    public override void AddToScore()
    {
        gManager.AddToScore(scoreValue);
    }
   
    // this update method shows the use of abstractions on the WhichMovement(); and JukeTimer();
    private void Update()
    {
        WhichMovement();
        JukeTimer();
    }
    void Juke()
    {
        float jukeFloat;
        timer = Random.Range(1f,5f);
        jukeFloat = Random.Range(0, 2);
        juke = (int)jukeFloat;
    }
    void WhichMovement()
    {
        if (juke == 1)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (juke == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (transform.position.x < -movementContainer)
        {
            juke = 2;
        }
        if (transform.position.x > movementContainer)
        {
            juke = 1;
        }
    }
    void JukeTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Juke();
        }
    }
}
        
