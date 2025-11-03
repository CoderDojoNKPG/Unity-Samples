using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public float speed = 5f;
	Vector2 moveInput;
    Vector2 rotateInput;

    Rigidbody rb;

    bool rotating = false;

	void Awake()
    {
        rb = GetComponent<Rigidbody>();
	}
    // Start is called before the first frame update
    void Start()
    {
        moveInput = new Vector2(0, 0);
	}

    // Update is called once per frame
    void Update()
    {
		// I förhållande till världen
		// rb.position += new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime;

		// I förhållande till spelaren
		rb.position += transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y)) * Time.deltaTime * speed;

        // rb.AddForce(moveInput.x,0,moveInput.y);
        if (rotating)
        {
            transform.Rotate(new Vector3(0, rotateInput.x, 0) * Time.deltaTime * 40 * speed);
		}
	}
    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.rotation = Quaternion.Euler(0, rb.rotation.y, 0);
			Debug.Log("Jump");
        }
	}
	void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>() * 10;
        Debug.Log("Move: " + moveInput);
	}
    void OnRotate(InputValue value)
    {
        rotating = true;
		rotateInput = value.Get<Vector2>();
        Debug.Log("Rotate: " + rotateInput);
	}
}
