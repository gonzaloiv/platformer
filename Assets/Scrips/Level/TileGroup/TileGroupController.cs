using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGroupController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject tilePrefab;
  private TileController tileController;

  private List<List<GameObject>> previousGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> currentGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> nextGroupObjects = new List<List<GameObject>>();

  private TileGroup currentTileGroup;
  private TileGroup previousTileGroup;
  private TileGroupType currentTileGroupType = TileGroupType.Up;

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

  #region Public Behaviour

  public void TileGroup(TileType[] currentTiles) {

    previousTileGroup = currentTileGroup;

    if (previousTileGroup.TileTypes != null)
      currentTileGroupType = SetGroupType(previousTileGroup.Type, previousTileGroup.TileTypes.Last());
    
    currentTileGroup = new TileGroup(currentTileGroupType, currentTiles);

    previousGroupObjects.ForEach(x => x.ForEach(y => y.SetActive(false)));
    nextGroupObjects = TileGroupTiles();
   
    previousGroupObjects = currentGroupObjects;
    currentGroupObjects = nextGroupObjects;

  }

  #endregion

  #region Private Behaviour

  // Sets GroupType depending on the previous TileGroup
  // TileGroupType: +1 turns right and -1 turns left

  private TileGroupType SetGroupType(TileGroupType previousGroupType, TileType previousCornerType) { 
    switch (previousCornerType) {
      case TileType.RightCorner:
        return (TileGroupType) ((int) previousGroupType + 1);
      case TileType.LeftCorner:
        return (TileGroupType) ((int) previousGroupType - 1);
      default:
        return previousGroupType;
    }
  }

  private List<List<GameObject>> TileGroupTiles() {

    List<List<GameObject>> tileGroupTiles = new List<List<GameObject>>();   
    int tileGroupTilesAmount = currentTileGroup.TileTypes.Count();
   
    for (int i = 0; i < tileGroupTilesAmount; i++) {

      if (i == 0 && previousTileGroup.TileTypes != null) {
        switch (previousTileGroup.TileTypes.Last()) {
          case TileType.RightCorner:
            tileGroupTiles.Add(tileController.Tile(TileType.FirstRight, currentTileGroupType));
            break;
          case TileType.LeftCorner: 
            tileGroupTiles.Add(tileController.Tile(TileType.FirstLeft, currentTileGroupType));
            break;
          default:
            tileGroupTiles.Add(tileController.Tile(TileType.Regular, currentTileGroupType));
            break;
        }
      }

      if (i == tileGroupTilesAmount - 2) // The Tile before the corner
        tileGroupTiles.Add(tileController.Tile(TileType.Last, currentTileGroupType));
      else
        tileGroupTiles.Add(tileController.Tile(currentTileGroup.TileTypes[i], currentTileGroupType));

    }

    return tileGroupTiles;

  }

  #endregion

}
