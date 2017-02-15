using UnityEngine;
using System;

public struct Tile  {

  #region Fields

  public TileType TileType { get { return tileType; } }
  private TileType tileType;

  public TileGroupType TileGroupType { get { return tileGroupType; } }
  private TileGroupType tileGroupType;

  public Vector3 Position { get { return position; } set { position = value; } }
  private Vector3 position;

  public Vector3 Rotation { get { return rotation; } set { rotation = value; } }
  private Vector3 rotation;

  #endregion

  #region Public Behaviour

  public Tile(TileType tileType, TileGroupType tileGroupType, Vector3 position, Vector3 rotation) {
    this.tileGroupType = tileGroupType;
    this.tileType = tileType;
    this.position = position;
    this.rotation = rotation;
  }

  #endregion
	
}