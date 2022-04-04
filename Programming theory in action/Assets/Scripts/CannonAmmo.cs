using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonAmmo : MonoBehaviour
{
    public GameManager gameManager;
    public int ammoID;
    public int ammo;
    public int ballAmmo;
    
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
   
    public void DestroyAmmo()
    {
        if (ammoID == ballAmmo)

            Destroy(this.gameObject);
        
    }
}
