using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator anim; 
  private CharacterController controller;

  private float animationSpeed = 0;
  private float previousYRotation;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
    controller = GetComponent<CharacterController>();
    previousYRotation = transform.rotation.y;
  }

  void FixedUpdate() {
    animationSpeed = Mathf.Abs(controller.velocity.x / 10);

    // Stops animation when direction changes
    if (transform.rotation.y != previousYRotation)
      animationSpeed = 0;  
    previousYRotation = transform.rotation.y;
   
    anim.SetFloat("Speed", animationSpeed);
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
