using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private Ground ground;

  private Environment environment;

  #endregion


  #region Mono Behaviour

  void Awake() {
    environment = GetComponent<Environment>();
    ground = Instantiate(groundPrefab, transform).GetComponent<Ground>();
  }

  void Start() {
    ground.Initialize(environment.GroundSize);
  }

  #endregion

}
