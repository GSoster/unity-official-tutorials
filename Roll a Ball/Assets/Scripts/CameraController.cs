using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;//the difference betwen the transform position of the mainCamera and the transform position of the player

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	/**
     * before each frame the camera position will be ajusted to the player position + offset.
     **/
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
