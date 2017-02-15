using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator anim; 
  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
    player = GetComponent<Player>();
  }

  void FixedUpdate() {
    anim.SetFloat("Speed", player.MoveDirection.sqrMagnitude);
  }

  void OnEnable() {
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
  }

  void OnDisable() {
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
  }

  void OnControllerColliderHit(ControllerColliderHit controllerColliderHit) {
    if (controllerColliderHit.gameObject.layer == (int) CollisionLayer.Ground)
      anim.SetBool("Jump", false);
  }

  #endregion

  #region Mono Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    anim.SetBool("Jump", true);
  }

  #endregion

}