using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectSpawner : MonoBehaviour {

  #region Protected Behaviour

  protected virtual Vector3 SetPosition(Tile tile) {
    return SetPosition(tile, new int[]{ 0, 4 });
  }

  protected virtual Vector3 SetLanePosition(Tile tile) {
    return SetPosition(tile, new int[] { 1, 3 });
  }
  
  protected virtual Vector3 SetPosition(Tile tile, int[] range) {

    Vector3 position = Vector3.zero;

    switch (tile.TileGroupType) {
      case TileGroupType.Up:
        position = tile.Position + new Vector3(Random.Range(0, 10), 0, Config.LanePosition[Random.Range(range[0], range[1])]);
        break;
      case TileGroupType.Right:
        position = tile.Position + new Vector3(Config.LanePosition[Random.Range(range[0], range[1])], 0, Random.Range(0, 10));
        break;
      case TileGroupType.Down:
        position = tile.Position + new Vector3(Random.Range(0, 10), 0, -Config.LanePosition[Random.Range(range[0], range[1])]);
        break;
      case TileGroupType.Left:
        position = tile.Position + new Vector3(-Config.LanePosition[Random.Range(range[0], range[1])], 0, Random.Range(0, 10));
        break;
    }

    if(Physics.OverlapSphere(position + new Vector3(0, 5, 0), 3).Length > 0) // TODO: mejorar esto
      return SetPosition(tile, range);
    else
      return position;

  }

  #endregion
    	
}
