using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{

    public Transform target;
    public float distanceH ;
    public float distanceV ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 nextpos = target.forward * -1 * distanceH + target.up * distanceV + target.position;

        this.transform.position = nextpos;

        this.transform.LookAt(target);
    }
}
