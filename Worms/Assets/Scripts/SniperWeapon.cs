using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperWeapon : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float weaponDmg;
    [SerializeField] private Transform weaponBarrel;

    private float rayDelay;
    void Start()
    {
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (rayDelay > 0) 
        {
            rayDelay -= Time.deltaTime;
            if (rayDelay <= 0) 
            {
                lineRenderer.enabled = false;
            }
        }
    }

    public void Shoot()
    {
        lineRenderer.enabled = true;
        rayDelay = 0.2f;

        RaycastHit hit;
        bool thereWasHit = Physics.Raycast(weaponBarrel.position, transform.forward, out hit, Mathf.Infinity);

        lineRenderer.SetPosition(0, weaponBarrel.position);

        Debug.LogError("Boom");

        if (thereWasHit)
        {
            ActivePlayerHealth activePlayerHealth = hit.collider.gameObject.GetComponent<ActivePlayerHealth>();

            if (activePlayerHealth != null)
            {
                activePlayerHealth.TakeDmg(weaponDmg);
                Debug.LogError("Ouch");
            }

            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, weaponBarrel.position + transform.forward * 50);
        }
    }
}
