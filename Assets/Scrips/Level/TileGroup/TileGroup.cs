using UnityEngine;
using System.Collections.Generic;
using System;

public struct TileGroup {

  public TileType[] TileTypes { get { return tileTypes; } }
  private TileType[] tileTypes;

  public TileGroup(TileType[] tileTypes) {
    this.tileTypes = tileTypes;
  }

}