using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasters : MonoBehaviour
{
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10000, Color.cyan);

         RaycastHit hit;

         if(Input.GetMouseButton(0))
         {
            if(Physics.Raycast(ray, out hit) == true)
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Debug.Log("El rayo toca con " + hit.transform.gameObject.tag);
            }
         }
    }
}
