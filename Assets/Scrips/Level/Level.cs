using UnityEngine;
using System;

public struct Level {

  #region Fields

  public int LevelNumber { get { return levelNumber; } }
  private int levelNumber;

  public TileGroup[] TileGroups { get { return tileGroups; } }
  private TileGroup[] tileGroups;

  #endregion
 
  #region Public Behaviour

  public Level(int levelNumber, TileGroup[] tileGroups) {
    this.levelNumber = levelNumber;
    this.tileGroups = tileGroups;
  }

  #endregion
	
}