using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

  #region Fields

  private int levelNumber = Config.InitialLevelNumber;

  public int GroundSize { get { return groundSize; } }
  private int groundSize;

  #endregion


  #region Public Behaviour

  public void Initialize(int groundSize) {
    this.groundSize = groundSize;
  }

  #endregion
	
}