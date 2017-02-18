using UnityEngine;
using System.Collections.Generic;

public class Config {

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.05f;
  public const int CameraDistanceToPlayer = 25;
  public const float CameraYRotation = 25;

  // World Generation Data
  public const float TileSize = 60.9f;
  public static Tile InitialTile = new Tile(TileType.Regular, TileGroupType.Up, new Vector3(-TileSize, 0, 0), new Vector3(-TileSize, 0, 0));
  public const int MaxTileGroupTileAmount = 3;
  public static float[] LanePosition = new float[] { 0f, -13.5f, -27f, -40.5f};

  public const int MaxTileCars = 1;
  public const int MaxTileStones = 1;
  public const int MaxTilePowerUps = 1;

  // Player
  public const float PlayerSpeed = 10f;
  public const float PlayerJumpSpeed = 70f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;
  public const float PlayerGrowingRatio = 1.1f;

}

public enum CollisionLayer {
  Ground = 8,
  Player = 9,
  Platform = 10,
  Enemy = 11,
  PowerUp = 12
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

public enum MapState {
  Up,
  Right,
  Down,
  Left
}