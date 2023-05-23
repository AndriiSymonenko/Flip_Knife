using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipKnife : MonoBehaviour
{
    public float flipForce = 500f; // Adjust this to control the force of the flip

    private Rigidbody knifeRigidbody;
    private bool isFlipping = false;

    private void Start()
    {
        knifeRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isFlipping)
        {
            StartFlip();
        }
    }

    private void StartFlip()
    {
        isFlipping = true;
       
        knifeRigidbody.AddForce(transform.up * flipForce);
        knifeRigidbody.AddTorque(Vector3.left * flipForce);
    }
}
