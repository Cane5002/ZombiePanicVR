using UnityEngine;

public class Zombie : MonoBehaviour {

    public GameObject alive;
    public GameObject dead;

    private Rigidbody zombieRigidbody;

    public int damage = 1;
    public float speed = 10f;
    public float deathSpan = 1f;
    public float stopDistance = 1f;

    private bool living = true;

    public void Awake() {
        zombieRigidbody = GetComponent<Rigidbody>();
    }

    //Zombie Movement
    private void FixedUpdate() {

        if (living) {
            //Get target movement vector
            Vector3 playerPosition = new Vector3();
            UnitManager.Instance.GetPlayerPosition(ref playerPosition);
            playerPosition.y = transform.position.y;

            //Rotate towards player
            transform.LookAt(playerPosition);

            //Move towards player
            if ((playerPosition - transform.position).magnitude > stopDistance) transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        }

    }


    //On hit with blunt weapons (head flies off)
    public void Club(Vector3 direction, float force) {

        living = false;

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
