using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public CharacterStats characterStats;
    public DynamicJoystick dynamicJoystick;
    public Animator animator;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        WindowsMovement();
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
        else
        {
            animator.SetBool("Walk", false);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void WindowsMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * characterStats.characterSpeed;
    }

    private void JoystickMovement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        //rb.AddForce(direction * characterStats.characterSpeed * Time.deltaTime, ForceMode.VelocityChange);

        //rb.velocity = new Vector3(horizontal * characterStats.characterSpeed * Time.deltaTime, rb.velocity.y, vertical * Time.deltaTime * characterStats.characterSpeed);
        rb.velocity = direction * characterStats.characterSpeed;
        if (rb.velocity != Vector3.zero)
            animator.SetBool("Walk", true);
        else
            animator.SetBool("Walk", false);
        //Debug.Log(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            animator.SetBool("Eat", true);
            animator.SetBool("Attack", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Worm")
        {
            animator.SetBool("Eat", true);
            animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Worm")
        {
            animator.SetBool("Eat", false);
            animator.SetBool("Attack", false);
        }
    }
}
