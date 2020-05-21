using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnTransform;
    public float bulletTime = 8f;
    public bool canshoot = true;


    public void ShootedButton()
    {
        if (GameManager.Instance.nBullets > 0)
        {
            if (canshoot)
            {
                GameManager.Instance.nBullets--;
                GameObject go = Instantiate(bullet, spawnTransform.position, spawnTransform.rotation);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.VelocityChange);

                Destroy(go, bulletTime);
            }
        }
    }
}

