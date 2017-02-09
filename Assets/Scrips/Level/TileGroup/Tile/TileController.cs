using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private GroundController groundController;

  [SerializeField] private GameObject backgroundPrefab;
  private BackgroundController backgroundController;

  private Tile previousTile = new Tile(-Config.TileSize, TileType.Regular);
  private Tile currentTile;

  #endregion

  #region Public Behavour

  public void Tile(int position, TileType tileType) {
    currentTile = new Tile(previousTile.Position + Config.TileSize, tileType);

    groundController.Ground(currentTile.Position, currentTile.Type);
    backgroundController.Background(currentTile.Position);

    previousTile = currentTile;
  }
 
  #endregion

  #region Mono Behaviour

  void Awake() {
    groundController = Instantiate(groundPrefab, transform).GetComponent<GroundController>();
    backgroundController = Instantiate(backgroundPrefab, transform).GetComponent<BackgroundController>();
  }

  #endregion

}
