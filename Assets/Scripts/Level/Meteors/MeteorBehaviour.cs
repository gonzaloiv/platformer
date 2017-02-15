using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class MeteorBehaviour : TileObjectBehaviour {

  #region Mono Behaviour

  void Update() {
    if(transform.position.y < -2)
      Disable();
  }

  #endregion

}
