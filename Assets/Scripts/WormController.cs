using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Catch", true);
            transform.Rotate(transform.position - other.transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0 ,0) - other.transform.rotation, 1.0f);
            animator.StopPlayback();
        }
    }
}
