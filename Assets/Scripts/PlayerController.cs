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

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        // rotate car, do not work with this line
//        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        verticalInput = Input.GetAxis("Vertical" + inputID);
        // Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * horsePower * verticalInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for kmh
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
