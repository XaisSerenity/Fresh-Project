using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float aliveTime;
    SphereCollider sphereCollider;
    public GameObject explosion;
    public float blastRadius = 5;
    public float explosionForce = 1400;
    private GameManager gameManager;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sphereCollider = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= 1 * Time.deltaTime;
        if (aliveTime <= 0)
        {
            WhenDestroyed();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Target"))
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);

            // Grabbing all nearby objects and putting them into an array
            Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

            // for each object in the array
            foreach(Collider nearbyObject in colliders)
            {
                //Giving each object in the array a rigidbody component variable
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

                //if there is a rigidbody component on the object add this explosion force
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
                }
            }
            WhenDestroyed();
            
        }
    }
    void WhenDestroyed()
    {
        gameManager.projectileDestroyed -= 1;
        Destroy(this.gameObject);
    }
}
