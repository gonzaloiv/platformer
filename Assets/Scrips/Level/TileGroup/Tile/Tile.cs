using UnityEngine;
using System;

public struct Tile  {

  #region Fields

  public float Position { get { return position; } }
  private float position;

  public TileType Type { get { return type; } }
  private TileType type;

  #endregion

  #region Public Behaviour

  public Tile(float position, TileType type) {
    this.position = position;
    this.type = type;
  }

  #endregion
	
}