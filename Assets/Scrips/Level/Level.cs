using UnityEngine;
using System.Collections.Generic;
using System;

public struct Level {

  #region Fields

  public int LevelNumber { get { return levelNumber; } }
  private int levelNumber;

  public List<TileGroup> TileGroups { get { return tileGroups; } }
  private List<TileGroup> tileGroups;

  #endregion
 
  #region Public Behaviour

  public Level(int levelNumber, List<TileGroup> tileGroups) {
    this.levelNumber = levelNumber;
    this.tileGroups = tileGroups;
  }

  #endregion
	
}