using UnityEngine;
using System.Collections.Generic;

public class Config {

  // Global

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.7f;
  public const int CameraDistanceToPlayer = 30;

  // World Generation Data
  public const float TileSize = 60.9f;
  public static Level InitialLevel = new Level(1, 5);
  public static Tile InitialTile = new Tile(TileType.Regular, new Vector3(-TileSize, 0, 0), new Vector3(-TileSize, 0, 0));
  public static TileType[] TileGroup1Tiles = new TileType[] { TileType.Regular, TileType.Regular, TileType.Regular, TileType.LeftCorner }; 

  // Player
  public const float PlayerSpeed = 10f;
  public const float PlayerJumpSpeed = 120f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;
 
}

public enum CollisionLayer {
  Ground = 8,
  Player = 9
}

public enum TileType {
  Regular,
  Last,
  FirstStraight,
  FirstLeft,
  FirstRight,
  LeftCorner,
  RightCorner,
}

public enum TileGroupType {
  Straight,
  Left,
  Right
}

public enum CameraState {
  Straight,
  Left,
  Right
}