using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class PlayerCollider : MonoBehaviour {

  #region Fields

  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    player = GetComponent<Player>();
  }

  void OnTriggerEnter(Collider collider) {

    if (collider.gameObject.name.Contains("LastTile"))
      EventManager.TriggerEvent(new LastTileEvent());

    if (collider.gameObject.name.Contains("LeftCorner"))
      player.TurnLeft();

    if (collider.gameObject.name.Contains("RightCorner"))
      player.TurnRight();

    if (collider.gameObject.layer == (int) CollisionLayer.PowerUp)
      player.GrowUp();

  }

  void OnControllerColliderHit(ControllerColliderHit controllerColliderHit) {
    if (controllerColliderHit.gameObject.layer == (int) CollisionLayer.Ground)
      player.IsGrounded = true;
    if (controllerColliderHit.gameObject.layer == (int) CollisionLayer.Enemy)
      player.LoseLife();
  }

  #endregion

}
