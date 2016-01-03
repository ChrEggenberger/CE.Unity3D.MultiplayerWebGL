using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - Player.transform.position;
	}
	
    /// <summary>
    /// like Update but as last one
    /// </summary>
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
