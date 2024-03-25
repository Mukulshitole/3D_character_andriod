using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjictile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] private Transform vfxhitgreen;
    [SerializeField] private Transform vfxhitred;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            // hit target
            Instantiate(vfxhitgreen, transform.position, Quaternion.identity);
        }
        else
        {
            // hit something else
            Instantiate(vfxhitred, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
