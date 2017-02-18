using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory {

  #region Fields

  private static Vector3 StraightIncrement = new Vector3(Config.TileSize, 0, 0);
  private static Vector3 LeftIncrement = new Vector3(0, 0, Config.TileSize);
  private static Vector3 RightIncrement = new Vector3(0, 0, -Config.TileSize);

  // TODO: refactorizar esto con Bit Wise Operators
  private static Vector3 RightFirstRightIncrement = new Vector3(64.1f, 0, -77.6f);
  private static Vector3 UpFirstRightIncrement = new Vector3(77.6f, 0, 64.1f);
  private static Vector3 DownFirstRightIncrement = new Vector3(-77.6f, 0, -64.1f);
  private static Vector3 LeftFirstRightIncrement = new Vector3(-64.1f, 0, 77.6f);

  private static Vector3 RightFirstLeftIncrement = new Vector3(-24f, 0, -37f);
  private static Vector3 UpFirstLeftIncrement = new Vector3(37f, 0, -24f);
  private static Vector3 DownFirstLeftIncrement = new Vector3(-37f, 0, 24f);
  private static Vector3 LeftFirstLeftIncrement = new Vector3(24f, 0, 37f);

  #endregion

  #region Public Behaviour

  public static Tile Tile(Tile previousTile, TileType tileType, TileGroupType tileGroupType) {

    Tile tile = new Tile(tileType, tileGroupType, previousTile.Position, previousTile.Rotation);

    if (tileType == TileType.FirstRight)
      return FirstRightTile(tile);

    if (tileType == TileType.FirstLeft)
      return FirstLeftTile(tile);

    switch (tileGroupType) {
      case TileGroupType.Right: 
        tile.Position += RightIncrement;
        break;
      case TileGroupType.Down: 
        tile.Position -= StraightIncrement;
        break;
      case TileGroupType.Left:
        tile.Position += LeftIncrement;
        break;
      default:
        tile.Position += StraightIncrement;
        tile.Rotation = Vector3.zero;
        break;
    }

    return tile;

  }

  #endregion

  #region Private Behaviour

  private static Tile FirstRightTile(Tile tile) {

    tile.Rotation += new Vector3(0, 90, 0);

    switch (tile.TileGroupType) {
      case TileGroupType.Right: 
        tile.Position += RightFirstRightIncrement;
        break;
      case TileGroupType.Up: 
        tile.Position += UpFirstRightIncrement;
        break;
      case TileGroupType.Down:
        tile.Position += DownFirstRightIncrement;
        break;
      case TileGroupType.Left:
        tile.Position += LeftFirstRightIncrement;
        break;
    } 

    return tile;

  }

  private static Tile FirstLeftTile(Tile tile) {

    tile.Rotation += new Vector3(0, -90, 0);

    switch (tile.TileGroupType) {
      case TileGroupType.Right: 
        tile.Position += RightFirstLeftIncrement;
        break;        
      case TileGroupType.Up: 
        tile.Position += UpFirstLeftIncrement;
        break;
      case TileGroupType.Down:
        tile.Position += DownFirstLeftIncrement;
        break;              
      case TileGroupType.Left:
        tile.Position += LeftFirstLeftIncrement;
        break;            
    }

    return tile;

  }

  #endregion

}