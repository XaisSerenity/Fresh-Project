using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Cannon : MonoBehaviour
{
    public float speedRotation;
    public float speedArcAngle;
    public float arcAngleConstraint;
    private float inputRotationY;
    private float inputAddAxisX;
    private float inputSubAxisX;
    public float inputAddpower;
    public float inputSubpower;
    public float powerSpeed;
    public float maxPower;
    public float currentPower;
    GameObject cannonBarrelRotator;

    public TextMeshProUGUI rotationText;
    public TextMeshProUGUI arcAngleText;
    public TextMeshProUGUI powerText;
    public float rotationYfloat;
    public int rotationYint;

    
    public Rigidbody cannonBallRB;
    public Transform projectileSpawn;

    GameManager gameManager;
    public bool gameOver;
    private void Awake()
    {
        cannonBarrelRotator = GameObject.Find("Cannon Barrel Rotator");
        arcAngleConstraint = 45;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    private void Start()
    {
        arcAngleConstraint = 45;
    }
    void Update()
    {
        if (gameManager.gameOver == false)
        {
            AxisChangeX();
            RotationY();
            PowerGauge();
            TextGauges();
        }
        
    }
    public void RotationY()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speedRotation * inputRotationY);
    }
    public void AxisChangeX()
    {

        if (arcAngleConstraint < 0.1)
        {
            arcAngleConstraint = 0.1f;

        }
        else if (arcAngleConstraint > 90.1)
        {
            arcAngleConstraint = 90.1f;
        }

        if (arcAngleConstraint >= 0.2)
        {
            cannonBarrelRotator.transform.Rotate(Vector3.right * inputSubAxisX * speedArcAngle * Time.deltaTime);
            arcAngleConstraint += inputSubAxisX * speedArcAngle * Time.deltaTime;
        }
        if (arcAngleConstraint <= 90)
        {
            cannonBarrelRotator.transform.Rotate(Vector3.right * inputAddAxisX * speedArcAngle * Time.deltaTime);
            arcAngleConstraint += inputAddAxisX * speedArcAngle * Time.deltaTime;
        }

       
   

    }
    void OnRotateAxisY(InputValue value)
    {
        inputRotationY = value.Get<float>();
    }
    void OnAddAxisX(InputValue value) => inputAddAxisX = value.Get<float>();
    void OnSubAxisX(InputValue value) => inputSubAxisX = value.Get<float>();
    void OnAddPower(InputValue value)
    {
        inputAddpower = value.Get<float>();
    }
    void OnSubPower(InputValue value)
    {
        inputSubpower = value.Get<float>();
    }
    void PowerGauge()
    {
        if (currentPower < 1)
        {
            currentPower = 1;
        }
        if (currentPower > 100)
        {
            currentPower = 100;
        }
        if (currentPower > 1)
        {
            currentPower += Time.deltaTime * inputSubpower * powerSpeed;
        }
        if (currentPower < 100)
        {
            currentPower += Time.deltaTime * inputAddpower * powerSpeed;
        }
    }
    void TextGauges()
    {
        rotationYfloat = transform.eulerAngles.y;
        rotationYint = (int)transform.eulerAngles.y;
        rotationText.SetText("Rotation: " + rotationYint);

        arcAngleText.SetText("Arc Angle: " + (int)arcAngleConstraint);

        powerText.SetText("Power: " + (int)currentPower + "%");
    }
    public void Shoot()
    {
        
            Rigidbody projectileInstance;

            projectileInstance = Instantiate(cannonBallRB, projectileSpawn.transform.position, projectileSpawn.transform.localRotation) as Rigidbody;
            projectileInstance.AddForce(projectileSpawn.up * currentPower, ForceMode.Impulse);
            
            //cannonBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * currentPower, ForceMode.Impulse);
        

    }
}
