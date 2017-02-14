using UnityEngine;
using System.Collections.Generic;

public struct TileGroup {

  public TileGroupType Type { get { return type; } }
  private TileGroupType type;

  public List<TileType> TilesType { get { return tilesType; } }
  private List<TileType> tilesType;

  public TileGroup(TileGroupType type, List<TileType> tilesType) {
    this.type = type;
    this.tilesType = tilesType;
  }

}