using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public bool gotItem1;
    public LayerMask layerMask;
    public float distance;
    public GameObject posts;
    public Slider a;
    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void Update()
    {

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))

            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                if (hit.collider.gameObject == item1.gameObject)
                {
                    hit.collider.gameObject.SetActive(false);
                    gotItem1 = true;
                }
                else if (hit.collider.gameObject == item2.gameObject && gotItem1)
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void post()
    {
        if (a.value >= 0.5)
        {
            posts.SetActive(false);
        }
        else
        {
            posts.SetActive(true);
        }
    }
}
