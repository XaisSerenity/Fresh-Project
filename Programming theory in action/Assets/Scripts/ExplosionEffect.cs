using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{

    private float destroyTimer = 2;
    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = destroyTimer;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
