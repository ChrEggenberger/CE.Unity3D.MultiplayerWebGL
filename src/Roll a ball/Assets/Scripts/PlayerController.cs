using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
    void Update()
    {
    }
    
    /// <summary>
    /// physics
    /// </summary>
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical") ;
        float moveHorizontal = Input.GetAxis("Horizontal") ;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * Speed);
    }
}
