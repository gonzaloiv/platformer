using UnityEngine;
using System;

public struct TileGroup {

  public int Tiles { get { return tiles; } }
  private int tiles;

  public TileGroup(int tiles) {
    this.tiles = tiles;
  }

}