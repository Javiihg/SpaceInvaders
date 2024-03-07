using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script donde se añade raycast para mantener el puntero de disparo, añadiendo un prefab cómo bala y y manteniendo un intervalo de balas cada medio segundo.
public class RayCasters : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float shootingInterval = 0.5f;
    public int shotsBeforePumpum = 15;
    public float cooldown = 2f;

    private bool canShoot = true;
    private int shotsCount = 0;
    private bool isReload = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload) 
        {
            StartCoroutine(RestartCooldown());
        }

        if (Input.GetMouseButtonDown(0) && canShoot && !isReload) 
        {
            ShootProjectile();
            StartCoroutine(ShootCooldown());
        }
    }

    void ShootProjectile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                Vector3 direction = ray.origin - firePoint.position;
                projectileRigidbody.velocity = direction.normalized * projectileSpeed;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<ChangeCursor>() != null)
            {
                Destroy(hit.transform.gameObject);
            }
        }

        shotsCount++;
        if (shotsCount >= shotsBeforePumpum)
        {
            StartCoroutine(StartCooldown());
            shotsCount = 0;
        }
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingInterval);
        canShoot = true;
    }

    IEnumerator StartCooldown()
    {
        isReload = true; 
        yield return new WaitForSeconds(cooldown);
        isReload = false; 
    }

    IEnumerator RestartCooldown()
    {
        isReload = true; 
        shotsCount = 0;
        yield return new WaitForSeconds(1f);
        isReload = false; 
    }
}