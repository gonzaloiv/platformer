using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroupController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject tilePrefab;
  private TileController tileController;
  private TileGroup tileGroup;

  #endregion

  #region Public Behaviour

  public void TileGroup(int tiles) {
    tileGroup = new TileGroup(tiles);
    for (int i = 0; i < tileGroup.Tiles; i++) {
      if (i == tileGroup.Tiles - 2)
        tileController.Tile(i, TileType.Last); // Sets the type to the tile before the corner
      else
        tileController.Tile(i, TileType.Regular);
    }
  }

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

}
