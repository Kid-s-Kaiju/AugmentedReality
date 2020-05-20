using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectGravity : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody rb;

    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (meshRenderer.enabled)
            rb.useGravity = true;

        else
            rb.useGravity = false;

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = position;
        }
            
    }
}
