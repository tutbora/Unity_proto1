using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    [SerializeField]
    public Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
