using UnityEngine;

public class Config {

  // Global

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.7f;

  // World Generation Data
  public const float TileSize = 60.9f;
  public const int TileGroup1Tiles = 3;
  public const int InitialLevelNumber = 1;
  public const int Lvl1TileGroups = 5;

  // Player Controller
  public const float PlayerSpeed = 15f;
  public const float PlayerJumpSpeed = 120f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;	

  // Environment
  public const int EnvironmentTileSize = 6;

}

public enum CollisionLayer {
  Ground = 8,
  Player = 9
}

public enum TileType {
  Regular,
  Last,
  Corner
}

public enum CornerType {
  Straight,
  Left,
  Right
}
