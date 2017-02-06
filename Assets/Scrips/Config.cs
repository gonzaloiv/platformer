using UnityEngine;

public class Config {

  // Global

  // Data

  // Level
  public const int InitialLevelNumber = 1;
  public const int Lvl1Size = 10;


  // Player Controller
  public const float PlayerSpeed = 5f;
  public const float PlayerJumpSpeed = 100f;
  public const float PlayerAcceleration = 0.2f;
  public const float PlayerGravityRatio = 1f;	
 
  // Enemies

}


public enum CollisionLayer {
  Ground = 8,
  Player = 9
}