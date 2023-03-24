using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float mass = 1;
    public float velocity { get; private set; }
    public Vector3 direction { get; private set; }

    private Vector3 prevPosition;

    public void Start() {
        prevPosition = transform.position;
    }

    public void FixedUpdate() {
        Vector3 newPosition = transform.position;
        direction = newPosition - prevPosition;
        velocity = direction.magnitude / Time.deltaTime;
        prevPosition = newPosition;
    }

    public float GetForce() {
        return mass * velocity * velocity;
    }
}
