using UnityEngine;
using System.Collections.Generic;
using System;

public struct TileGroup {

  public TileGroupType Type { get { return type; } }
  private TileGroupType type;

  public TileType[] TileTypes { get { return tileTypes; } }
  private TileType[] tileTypes;

  public TileGroup(TileGroupType type, TileType[] tileTypes) {
    this.type = type;
    this.tileTypes = tileTypes;
  }

}