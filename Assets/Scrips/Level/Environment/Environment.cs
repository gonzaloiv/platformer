using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

  #region Fields

  public int GroundSize { get { return groundSize; } }
  private int groundSize;

  #endregion

  #region Public Behaviour

  public void Initialize(int groundSize) {
    this.groundSize = groundSize;
  }

  #endregion

}
