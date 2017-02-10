using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory {

  #region Fields

  private static Vector3 StraightIncrement = new Vector3(Config.TileSize, 0, 0);
  private static Vector3 LeftIncrement = new Vector3(0, 0, Config.TileSize);
  private static Vector3 RightIncrement = new Vector3(0, 0, -Config.TileSize);

  #endregion

	#region Public Behaviour

  public static Tile TileByTileGroupType(int index, Tile previousTile, TileType tileType, TileGroupType tileGroupType) {
    switch(tileGroupType) {
      case TileGroupType.Left:
        if(tileType == TileType.First)
          return new Tile(TileType.First, tileGroupType, previousTile.Position + new Vector3(24f, 0, 37.8f), new Vector3(0, -90, 0));
        else 
          return new Tile(tileType, tileGroupType, previousTile.Position + RightIncrement, new Vector3(0, -90, 0));
      case TileGroupType.Right: 
        if(tileType == TileType.First)
          return new Tile(TileType.First, tileGroupType, previousTile.Position + new Vector3(24f, 0, -37f), new Vector3(0, -90, 0));
        else 
          return new Tile(tileType, tileGroupType, previousTile.Position + LeftIncrement, new Vector3(0, -90, 0));
      default:
        return new Tile(tileType, tileGroupType, previousTile.Position + StraightIncrement, Vector3.zero);
    }
  }

  #endregion

}