using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGroupFactory {

  #region Fields



  #endregion


  #region Public Behaviour

  // Sets GroupType depending on the previous TileGroup
  // TileGroupType: +1 turns right and -1 turns left

  public static TileGroupType SetType(TileGroupType previousGroupType, TileType previousCornerType) {
    switch (previousCornerType) {
      case TileType.RightCorner:
        return (TileGroupType) ((int) previousGroupType + 1);
      case TileType.LeftCorner:
        return (TileGroupType) ((int) previousGroupType - 1);
      default:
        return previousGroupType;
    }
  }

  public static List<List<GameObject>> SetTiles(TileController tileController, TileGroup previousTileGroup, TileGroup currentTileGroup) {

    List<List<GameObject>> tileGroupTiles = new List<List<GameObject>>();   
    int tileGroupTilesAmount = currentTileGroup.TileTypes.Count();
   
    for (int i = 0; i < tileGroupTilesAmount; i++) {

      if (i == 0 && previousTileGroup.TileTypes != null) {
        switch (previousTileGroup.TileTypes.Last()) {
          case TileType.RightCorner:
            tileGroupTiles.Add(tileController.Tile(TileType.FirstRight, currentTileGroup.Type));
            break;
          case TileType.LeftCorner: 
            tileGroupTiles.Add(tileController.Tile(TileType.FirstLeft, currentTileGroup.Type));
            break;
          default:
            tileGroupTiles.Add(tileController.Tile(TileType.Regular, currentTileGroup.Type));
            break;
        }
      }

      if (i == tileGroupTilesAmount - 2) // The Tile before the corner
        tileGroupTiles.Add(tileController.Tile(TileType.Last, currentTileGroup.Type));
      else
        tileGroupTiles.Add(tileController.Tile(currentTileGroup.TileTypes[i], currentTileGroup.Type));

    }

    return tileGroupTiles;

  }


  #endregion

}
