using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnifeForceController : MonoBehaviour
{
    public Transform knife; // Transform of the knife object
    public float minDistance = 1f; // Minimum distance for minimum force
    public float maxDistance = 10f; // Maximum distance for maximum force
    public float maxForce = 500f; // Maximum force to be applied

    private Rigidbody knifeRigidbody;
    private float currentForce;

    private bool isDragging = false;
    private Vector3 offset;


    private void Start()
    {
        knifeRigidbody = knife.GetComponent<Rigidbody>();
        currentForce = 0f;
    }

 
    private void Update()
    {
        float distance = Vector3.Distance(knife.position, transform.position);

        // Calculate the force based on the distance
        float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
        currentForce = Mathf.Lerp(0f, maxForce, normalizedDistance);

        if (Input.GetMouseButtonUp(0))
        {
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        Vector3 direction = (transform.position - knife.position).normalized;
        knifeRigidbody.AddForce(direction * currentForce, ForceMode.Impulse);
        knifeRigidbody.AddTorque(Vector3.forward * 1000000000000);
    }

    //Drag object
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}

