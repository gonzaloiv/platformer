using UnityEngine;
using System.Collections.Generic;

public class Config {

  // Global

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.7f;

  // World Generation Data
  public const float TileSize = 60.9f;
  public static Vector3 InitialTilePosition = new Vector3(-TileSize, 0, 0);
  public static Vector3 InitialTileRotation = new Vector3(-TileSize, 0, 0);
  public static TileType[] TileGroup1Tiles = new TileType[] { TileType.Regular, TileType.Regular, TileType.Regular, TileType.RightCorner }; 
  public const int InitialLevelNumber = 1;

  // Player Controller
  public const float PlayerSpeed = 10f;
  public const float PlayerJumpSpeed = 120f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;	
 
}

public enum CollisionLayer {
  Ground = 8,
  Player = 9
}

public enum TileType { // Flag for the prefabs to pool for the tiles
  Regular,
  Last,
  First,
  LeftCorner,
  RightCorner,
}

public enum TileGroupType { // Flag for the position and the rotation of the group tiles
  Straight,
  Left,
  Right
}
