using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

  #region Fields

  private int levelNumber = Config.InitialLevelNumber;

  public CameraController CameraController { get { return this.cameraController; } }
  private CameraController cameraController;

  public int GroundSize { get { return groundSize; } }
  private int groundSize;

  #endregion
 
  #region Public Behaviour

  public void Initialize(CameraController cameraController, int groundSize) {
    this.cameraController = cameraController;
    this.groundSize = groundSize;
  }

  #endregion
	
}