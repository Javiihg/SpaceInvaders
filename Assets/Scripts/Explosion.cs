using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    
    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
