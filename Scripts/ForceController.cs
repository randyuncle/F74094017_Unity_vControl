using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

/**
 * a.k.a jumping controller
 */
public class ForceController : MonoBehaviour
{
    public Vector3 ForceDirection;
    public float Force;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Force * ForceDirection);
            Debug.Log("space pressed");
        }
    }
}
