using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : StaticInstance<UnitManager> {

    // Player

    GameObject player;
    bool playerReceived = false;

    public void SetPlayer(GameObject _player) {
        player = _player;
        playerReceived = true;
    }

    //Tooltip: Returns true if the position is valid
    public bool GetPlayerPosition(ref Vector3 returnPosition) {
        if (playerReceived) returnPosition = player.transform.position;
        return playerReceived;
    }

    // Spawner

    Spawner spawner;
    bool spawnerReceived = false;

    public void SetSpawner(Spawner _spawner) {
        spawner = _spawner;
        spawnerReceived = true;
    }

    public Spawner GetSpawner() {
        if (spawnerReceived) return spawner;
        return null;
    }

}
