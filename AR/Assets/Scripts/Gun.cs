using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.nBullets > 0)
        {
            GameManager.Instance.nBullets--;
            GameObject go = Instantiate(bullet, spawnTransform.position, spawnTransform.rotation);
            go.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.VelocityChange);
        }
    }
}
