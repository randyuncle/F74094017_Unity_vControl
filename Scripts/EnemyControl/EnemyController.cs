using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public CharacterController controller;

    [SerializeField]
    float moveSpeed ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = player.position - transform.position;
        distance = distance.normalized;

        Vector3 velocity = distance * moveSpeed ;
        transform.Translate(velocity * Time.deltaTime);
        transform.LookAt(player);
    }
}
