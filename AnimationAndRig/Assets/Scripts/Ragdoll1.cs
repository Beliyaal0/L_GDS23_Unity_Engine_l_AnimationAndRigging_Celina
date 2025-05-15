using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll1 : MonoBehaviour
{
    public Collider[] ragdollCollider;
    public Rigidbody[] ragdollrigidbodies;
    private Collider mainCollider;
    //private Animator anim;jxj
    private void Awake()
    {
        ragdollCollider = GetComponentsInChildren<Collider>();
        ragdollrigidbodies = GetComponentsInChildren<Rigidbody>();
        mainCollider = GetComponent<Collider>();
        //anim = GetComponent<Animator>();
        DisableRagdoll();
    }
    private void DisableRagdoll()
    {
        foreach (Collider c in ragdollCollider)
        {
            c.enabled = false;

        }
        foreach (Rigidbody r in ragdollrigidbodies)
        {
            r.isKinematic = true;
        }

        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        //anim.enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnableRagdoll();
        }
    }
    public void EnableRagdoll()
    { 
        //anim.enabled = false;
        GetComponent<Rigidbody>().useGravity = false;

        foreach (Collider c in ragdollCollider)
        {
            c.enabled = true;
        }
        mainCollider.enabled = false;
        foreach (Rigidbody r in ragdollrigidbodies)
        {
            r.isKinematic = false;
        }
    }
}
