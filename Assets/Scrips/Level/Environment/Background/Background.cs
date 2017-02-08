using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

  #region Fields

  public int Size { get { return size; } }
  private int size;

  #endregion

  #region Public Behaviour

  public void Initialize(int size) {
    this.size = size;
  }

  #endregion

}
