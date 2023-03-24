using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour {

    private Collider zombieCollider;
    public void Awake() {
        zombieCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Weapon")) {
            Debug.Log("Collision Detected");
            Weapon weapon = other.GetComponent<Weapon>();
            transform.parent.GetComponentInParent<Zombie>().Club(weapon.direction, weapon.GetForce());
        }
    }
}
