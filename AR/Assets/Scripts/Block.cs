using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector3 startPosition;
    private float lastCheck;
    private bool hasFallen = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFallen)
            return;

        if (gameObject.GetComponent<MeshRenderer>().enabled)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (Time.time - lastCheck > 1)
            {
                lastCheck = Time.time;

                if (Vector3.Magnitude(transform.position - startPosition) > 1)
                {
                    hasFallen = true;
                    GameManager.Instance.RemoveBlock(gameObject);
                }
            }
        }
    }
}
