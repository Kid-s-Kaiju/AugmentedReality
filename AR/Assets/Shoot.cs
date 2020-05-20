using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                Rigidbody rb = shot.GetComponent<Rigidbody>();
                shot.transform.LookAt(hit.point);
                rb.velocity = rb.transform.forward * 10;
            }
        }
    }
}
