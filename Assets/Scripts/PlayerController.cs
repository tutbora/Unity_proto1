using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float verticalInput;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        // rotate car, do not work with this line
//        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        verticalInput = Input.GetAxis("Vertical" + inputID);
        if (IsOnGround()) {
            // Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.Translate(Vector3.forward * horsePower * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for kmh
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }

    bool IsOnGround() {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels) {
            if(wheel.isGrounded) {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4) {
            return true;
        } else {
            return false;
        }
    }
}

////using System.Collections;
//using System.Collections.Generic;
////using System.Numerics;
//using UnityEngine;
//using TMPro;
//
//public class PlayerController : MonoBehaviour
//{
//
//    [SerializeField] float speed;
//    [SerializeField] float rpm;
//    [SerializeField] private float horsePower = 0;
//    [SerializeField] float turnSpeed = 30.0f;
//    private float horizontalInput;
//    private float forwardInput;
//    private Rigidbody playerRb;
//
//    [SerializeField] GameObject centerOfMass;
//    [SerializeField] TextMeshProUGUI speedometerText;
//    [SerializeField] TextMeshProUGUI rpmText;
//
//    [SerializeField] List<WheelCollider> allWheels;
//    [SerializeField] int wheelsOnGround;
//
//    private void Start()
//    {
//        playerRb = GetComponent<Rigidbody>();
////        playerRb.centerOfMass = centerOfMass.transform.position;
//    }
//
//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        //Get Input from player
//        horizontalInput = Input.GetAxis("Horizontal");
//        forwardInput = Input.GetAxis("Vertical");
//
//        if (IsOnGround())
//        {
//            //Move the vehicle forward
//            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
//            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
//            //Turning the vehicle
//            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
//
//            //print speed
//            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
//            speedometerText.SetText("Speed: " + speed + " mph");
//
//            //print RPM
//            rpm = Mathf.Round((speed % 30) * 40);
//            rpmText.SetText("RPM: " + rpm);
//        }
//    }
//
//    bool IsOnGround() {
//        wheelsOnGround = 0;
//        foreach (WheelCollider wheel in allWheels) {
//            if (wheel.isGrounded)
//            {
//                wheelsOnGround++;
//            }
//        }
//            if (wheelsOnGround == 4)
//            {
//                return true;
//            } else
//            {
//                return false;
//            }
//    }
//}