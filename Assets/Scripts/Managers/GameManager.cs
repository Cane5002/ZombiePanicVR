using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {

    [SerializeField]
    GameState gamestate;

    private void Start() => gamestate = GameState.Start;

    private void Update() {
        switch(gamestate) {
            case GameState.Start:
                UnitManager.Instance.GetSpawner().BeginSpawn();
                gamestate = GameState.Play;
                break;
            case GameState.Play:
                break;
        }
    }

}

enum GameState {
    Start = 0,
    Play = 1
}