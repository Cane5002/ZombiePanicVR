using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public GameObject alive;
    public GameObject dead;

    private Rigidbody zombieRigidbody;

    public int damage = 1;
    public float speed = 10f;
    public float deathSpan = 1f;

    public void Awake() {
        zombieRigidbody = GetComponent<Rigidbody>();
    }

    //On hit with blunt weapons (head flies off)
    public void Club(Vector3 direction, float force) {
        //Split head and body
        alive.SetActive(false);
        dead.SetActive(true);

        //Apply force to head
        Rigidbody head = dead.transform.GetChild(0).GetComponent<Rigidbody>();
        head.AddForce(direction.normalized * force, ForceMode.Impulse);

        //Apply force to body
        Rigidbody body = dead.transform.GetChild(1).GetComponent<Rigidbody>();
        body.AddForce(direction.normalized * force, ForceMode.Impulse);

        //Controller Vibration

        //Trigger death animation
        Destroy(this.gameObject, deathSpan);
    }


}
