using UnityEngine;

public class Config {

  // Global

  // Camera
  public static Vector3 CameraInitialPosition = new Vector3(0, 10, -23);
  public const float CameraMaxSpeed = 0.5f;

  // Data

  // Level
  public const int InitialLevelNumber = 1;
  public const int Lvl1Size = 10;

  // Player Controller
  public const float PlayerSpeed = 5f;
  public const float PlayerJumpSpeed = 120f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 2f;	

  // Environment
  public const int EnvironmentTileSize = 6;

  // Enemies

}


public enum CollisionLayer {
  Ground = 8,
  Player = 9
}