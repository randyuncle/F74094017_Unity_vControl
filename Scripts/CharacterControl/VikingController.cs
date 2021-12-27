using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    public float force;

    private float turnRate = 5.0f;// build frame = 10 * compiler frame
    private float turnTrigger = 0f;
    private bool isCaught = false;

    Animator animator;
    Rigidbody rb;
    RaycastHit raycastHit;

    //MeshRenderer mr;
    [SerializeField] float movingSpeed = 10f;
    public bool onGround = true;
    bool run = true;
    

    // Start is called before the first frame update
    void Start()
    {
        Transform t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        run = true;
        onGround = true;
        //Debug.Log("on ground = " + collision.transform.name);
        if(collision.transform.name == "enemy")
        {
            isCaught = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //dead -> fall out of the world
        if((this.transform.localPosition.y < 0) || isCaught)
        {
            run = false;
            turnTrigger = 0;
            ReturnButtonController.isDead = true;
        }
        else
        {
            turnTrigger++;
            //moving forward
            transform.Translate(movingSpeed * Time.deltaTime * Vector3.forward);

            if (Input.GetKey(KeyCode.A) && (turnTrigger > turnRate))
            {
                transform.Rotate(Vector3.up * -90);
                turnTrigger = 0;
            }

            if (Input.GetKey(KeyCode.D) && (turnTrigger > turnRate))
            {
                transform.Rotate(Vector3.up * 90);
                turnTrigger = 0;
            }


            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                onGround = false;
                run = false;
                rb.AddForce(force * Vector3.up);
            }
        }
        animator.SetBool("Run", run);
    }
}
