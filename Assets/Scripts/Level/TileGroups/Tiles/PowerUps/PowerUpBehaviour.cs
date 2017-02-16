using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : TileObjectBehaviour {

  #region Mono Behaviour

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.layer == (int) CollisionLayer.Player)
      Disable();
  }

  #endregion

}
