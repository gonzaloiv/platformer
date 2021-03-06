﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour {

  #region Mono Behaviour

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.layer == (int) CollisionLayer.Player)
      gameObject.SetActive(false);
  }

  #endregion

}
