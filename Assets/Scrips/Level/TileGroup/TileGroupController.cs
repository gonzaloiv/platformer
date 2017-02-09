using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGroupController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject tilePrefab;
  private TileController tileController;
  private TileGroup tileGroup;

  private List<List<GameObject>> previousGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> currentGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> nextGroupObjects = new List<List<GameObject>>();

  #endregion

  #region Public Behaviour

  public void TileGroup(int tiles) {
    tileGroup = new TileGroup(tiles);

    previousGroupObjects.ForEach(x => x.ForEach(y => y.SetActive(false)));

    nextGroupObjects = new List<List<GameObject>>();
    nextGroupObjects = NextTiles(tiles);
   
    previousGroupObjects = currentGroupObjects;
    currentGroupObjects = nextGroupObjects;
  }

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

  #region Private Behaviour

  private List<List<GameObject>> NextTiles(int tiles) {
    List<List<GameObject>> nextTiles = new List<List<GameObject>>();   
    for (int i = 0; i < tileGroup.Tiles; i++) {
      if (i == tileGroup.Tiles - 2)
        nextTiles.Add(tileController.Tile(i, TileType.Last)); // Sets the type to the tile before the corner
      else
        nextTiles.Add(tileController.Tile(i, TileType.Regular));
    }
    return nextTiles;
  }

  #endregion

}
