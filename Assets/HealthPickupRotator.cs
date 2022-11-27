using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    public float xAngle = 0, yAngle = 0, zAngle = 90f;
    private void Update() => transform.Rotate(xAngle, yAngle, zAngle * rotationSpeed * Time.deltaTime);
}
