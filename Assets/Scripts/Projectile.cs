using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform player;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        Vector3 directionToPlayer = player.position - transform.position.normalized;
        rb.velocity = directionToPlayer * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
