using UnityEngine;
using System.Collections.Generic;

public class Config {

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.3f;
  public const int CameraDistanceToPlayer = 25;
  public const float CameraYRotation = 25;

  // World Generation Data
  public const float TileSize = 60.9f;
  public static Tile InitialTile = new Tile(TileType.Regular, TileGroupType.Up, new Vector3(-TileSize, 0, 0), new Vector3(-TileSize, 0, 0));
  public const int MaxTileGroupTileAmount = 8;

  // Player
  public const float PlayerSpeed = 10f;
  public const float PlayerJumpSpeed = 120f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;
 
}

public enum CollisionLayer {
  Ground = 8,
  Player = 9,
  Stone = 10
}

public enum TileType {
  Regular,
  LeftCorner,
  RightCorner,
  Last,
  FirstLeft,
  FirstRight
}

public enum TileGroupType {
  Up,
  Right,
  Down,
	Left
}

public enum CameraState {
  Up,
  Right,
  Down,
  Left
}