using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnDistance = 5f;
    public float spawnTimeMin = 3f;
    public float spawnTimeMax = 4.5f;

    public GameObject[] prefabs;


    private void Start() {
        UnitManager.Instance.SetSpawner(this);
    }

    public void BeginSpawn() {
        StartCoroutine(Spawn());
        Debug.Log("Begin Zombie spawn");
    }

    public void StopSpawn() {
        StopAllCoroutines();
        Debug.Log("End Zombie spanw");
    }

    private IEnumerator Spawn() {
        while (enabled) {
            GameObject toSpawn = prefabs[0];

            Vector3 spawnPosition = transform.position + (RandomDirection() * spawnDistance);

            Instantiate(toSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }

    private Vector3 RandomDirection() {
        Vector2 temp;
        do {
            temp = Random.insideUnitCircle.normalized;
        } while (temp.magnitude == 0);
        return new Vector3(temp.x, 0, temp.y);
    }

}
