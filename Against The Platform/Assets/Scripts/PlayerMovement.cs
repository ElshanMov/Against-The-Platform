using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizantalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizantalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
                
    }

    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
