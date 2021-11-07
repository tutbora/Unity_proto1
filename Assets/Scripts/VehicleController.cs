using UnityEngine;

public class VehicleController : MonoBehaviour {
    public float speed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // Move the vehicle forward
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
}
