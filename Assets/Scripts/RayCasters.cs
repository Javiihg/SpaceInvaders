using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasters : MonoBehaviour
{
    private bool isMouseClicked = false;
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (isMouseClicked || Input.GetMouseButton(0))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10000, Color.cyan);

        }

         RaycastHit hit;

         if(Input.GetMouseButton(0))
         {
            if(Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Debug.Log("El rayo toca con " + hit.transform.gameObject.tag);

                if (hit.transform.GetComponent<ChangeCursor>() != null)
                {
                    Destroy(hit.transform.gameObject);
                }
            }

            isMouseClicked = true;
         }
         else if (Input.GetMouseButtonUp(0))
         {
            isMouseClicked = false;
         }
    }
}
