using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] powerUpPrefabs;
  private GameObjectArrayPool powerUpPool;

  private float yPosition = 5;

  #endregion

  #region Mono Behaviour

  void Awake() {
    powerUpPool = new GameObjectArrayPool("PowerUpPool", powerUpPrefabs, 5, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {

    List<GameObject> powerUps = new List<GameObject>();

    for (int i = 0; i < Random.Range(0, 2); i++) {
      GameObject powerUp = powerUpPool.PopRandomObject();
      powerUp.transform.position = SetPosition(tile);
      powerUp.SetActive(true);
      powerUps.Add(powerUp);
    }

    return powerUps;

  }

  #endregion

  #region Private Behaviour

  private Vector3 SetPosition(Tile tile) {
    switch (tile.TileGroupType) {
      case TileGroupType.Up:
        return tile.Position + new Vector3(Random.Range(0, 10), yPosition, 0);
      case TileGroupType.Right:
        return tile.Position + new Vector3(0, yPosition, Random.Range(0, 10));
      case TileGroupType.Down:
        return tile.Position + new Vector3(Random.Range(0, 10), yPosition, 0);
      case TileGroupType.Left:
        return tile.Position + new Vector3(0, yPosition, Random.Range(0, 10));
      default:
        return Vector3.zero;
    }
  }

  #endregion
}
