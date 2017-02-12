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

  private TileGroupType tileGroupType = TileGroupType.Straight;

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

  #region Public Behaviour

  public void TileGroup(TileType[] tiles) {
    if (tileGroup.TileTypes != null)
      tileGroupType = SetGroupType(tileGroup.TileTypes.Last());
    tileGroup = new TileGroup(tiles);

    previousGroupObjects.ForEach(x => x.ForEach(y => y.SetActive(false)));
    nextGroupObjects = TileGroupTiles();
   
    previousGroupObjects = currentGroupObjects;
    currentGroupObjects = nextGroupObjects;
  }

  #endregion

  #region Private Behaviour

  private TileGroupType SetGroupType(TileType tileType) { // Sets GroupType depending on the last Tile of the previous TileGroup
    switch (tileType) {
      case TileType.LeftCorner:
        return TileGroupType.Left;
      case TileType.RightCorner:
        return TileGroupType.Right;
      default:
        return TileGroupType.Straight;
    }
  }

  private List<List<GameObject>> TileGroupTiles() {

    List<List<GameObject>> tileGroupTiles = new List<List<GameObject>>();   
    int tileGroupTilesAmount = tileGroup.TileTypes.Count();

    for (int i = 0; i < tileGroupTilesAmount; i++) {
      if (i == 0) {
        switch(tileGroupType) {
          case TileGroupType.Left: 
            tileGroupTiles.Add(tileController.Tile(TileType.FirstLeft, tileGroupType));
            break;
          case TileGroupType.Right:
            tileGroupTiles.Add(tileController.Tile(TileType.FirstRight, tileGroupType));
            break;
          default:
            tileGroupTiles.Add(tileController.Tile(TileType.FirstStraight, tileGroupType));
            break;
        }
      }
      else if (i == tileGroupTilesAmount - 2) // The Tile before the corner
        tileGroupTiles.Add(tileController.Tile(TileType.Last, tileGroupType));
      else
        tileGroupTiles.Add(tileController.Tile(tileGroup.TileTypes[i], tileGroupType));
    }

    return tileGroupTiles;

  }

  #endregion

}
