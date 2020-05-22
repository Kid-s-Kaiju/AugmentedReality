
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector3 startPosition;
    private float lastCheck;
    private bool hasFallen = false;
    private Animator animatorr;
    bool ReadyToDestroy = false;

    private void Start()
    {
        startPosition = transform.position;
        animatorr = gameObject.GetComponent<Animator>();
    }

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

                if (GameManager.Instance.currentLevel == 0)
                {
                    if (Vector3.Magnitude(transform.localPosition - startPosition) > 5)
                    {
                        hasFallen = true;
                        animatorr.SetBool("FadeStart", true);
                        GameManager.Instance.RemoveBlock(gameObject);
                        GameManager.Instance.score += 100;
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (Vector3.Magnitude(transform.position - startPosition) > 5)
                    {
                        hasFallen = true;
                        animatorr.SetBool("FadeStart", true);
                        GameManager.Instance.RemoveBlock(gameObject);
                        GameManager.Instance.score += 100;
                        Destroy(gameObject);
                    }
                }      
            }
        }
    }

    private IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(5);
        GameManager.Instance.RemoveBlock(gameObject);
        Destroy(gameObject);
    }
}
