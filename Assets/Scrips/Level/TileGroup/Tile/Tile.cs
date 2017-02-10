using UnityEngine;
using System;

public struct Tile  {

  #region Fields

  public TileType TileType { get { return tileType; } }
  private TileType tileType;

  public Vector3 Position { get { return position; } }
  private Vector3 position;

  public Vector3 Rotation { get { return rotation; } }
  private Vector3 rotation;

  #endregion

  #region Public Behaviour

  public Tile(TileType tileType, Vector3 position, Vector3 rotation) {
    this.tileType = tileType;
    this.position = position;
    this.rotation = rotation;
  }

  #endregion
	
}