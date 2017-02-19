using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CornerBehaviour : MonoBehaviour {

  #region Mono Behaviour

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.layer == (int) CollisionLayer.Player)
      GetComponents<CapsuleCollider>().ToList().ForEach(x => x.enabled = false);
  }

  #endregion

}
