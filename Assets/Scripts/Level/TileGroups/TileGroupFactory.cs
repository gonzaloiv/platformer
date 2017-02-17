using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGroupFactory {

  #region Fields

  private static TileGroup currentTileGroup;
  private static TileGroup previousTileGroup;

  #endregion

  #region Public Behaviour

  public static TileGroup TileGroup() {
    
    previousTileGroup = currentTileGroup;
    currentTileGroup = previousTileGroup.TilesType == null ? new TileGroup(TileGroupType.Up, SetTilesType(previousTileGroup)) : new TileGroup(SetType(previousTileGroup), SetTilesType(previousTileGroup));

    return currentTileGroup;
  }

  // Sets GroupType depending on the previous TileGroup
  // TileGroupType: +1 turns right and -1 turns left

  public static TileGroupType SetType(TileGroup previousTileGroup) {

    TileGroupType previousTileGroupType = previousTileGroup.Type;
    TileType previousLastTile = previousTileGroup.TilesType.Last();

    switch (previousLastTile) {
      case TileType.RightCorner:
        return (int) previousTileGroupType < 3 ? (TileGroupType) ((int) previousTileGroupType + 1) : (TileGroupType) 0;
      case TileType.LeftCorner:
        return (int) previousTileGroupType > 0 ? (TileGroupType) ((int) previousTileGroupType - 1) : (TileGroupType) 3;
      default:
        return previousTileGroupType;
    }
  }

  public static List<TileType> SetTilesType(TileGroup previousTileGroup) {

    List<TileType> tilesType = new List<TileType>();   
    int tileGroupTilesAmount = Random.Range(4, Config.MaxTileGroupTileAmount);
   
    for (int i = 0; i < tileGroupTilesAmount; i++) {

      if (i == 0 && previousTileGroup.TilesType != null) {
        switch (previousTileGroup.TilesType.Last()) {
          case TileType.RightCorner:
            tilesType.Add(TileType.FirstRight);
            break;
          case TileType.LeftCorner: 
            tilesType.Add(TileType.FirstLeft);
            break;
          default:
            tilesType.Add(TileType.Regular);
            break;
        }
      }

      if (i == tileGroupTilesAmount - 2) // The Tile before the corner
        tilesType.Add(TileType.Last);

//      if (i == tileGroupTilesAmount - 1) // Corner Tile
//        tilesType.Add((TileType) Random.Range(0, 3));

      else
        tilesType.Add(TileType.Regular);

    }

    return tilesType;

  }


  #endregion

}
