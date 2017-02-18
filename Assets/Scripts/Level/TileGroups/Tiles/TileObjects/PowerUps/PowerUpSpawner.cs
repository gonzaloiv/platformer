using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : TileObjectSpawner {

  #region Fields

  [SerializeField] private GameObject[] powerUpPrefabs;
  private GameObjectArrayPool powerUpPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    powerUpPool = new GameObjectArrayPool("PowerUpPool", powerUpPrefabs, 5, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {

    List<GameObject> powerUps = new List<GameObject>();

    for (int i = 0; i < Random.Range(0, Config.MaxTilePowerUps + 1); i++) {
      GameObject powerUp = powerUpPool.PopRandomObject();
      powerUp.transform.position = SetPosition(tile);
      powerUp.SetActive(true);
      powerUps.Add(powerUp);
    }

    return powerUps;

  }

  #endregion

}
