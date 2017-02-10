using UnityEngine;
using System.Collections.Generic;
using System;

public struct Level {

  #region Fields

  public int LevelNumber { get { return levelNumber; } }
  private int levelNumber;

  public int TileGroups { get { return tileGroups; } set { tileGroups = value; } }
  private int tileGroups;

  #endregion
 
  #region Public Behaviour

  public Level(int levelNumber, int tileGroups) {
    this.levelNumber = levelNumber;
    this.tileGroups = tileGroups;
  }

  #endregion
	
}