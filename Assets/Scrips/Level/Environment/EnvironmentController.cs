using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private Ground ground;

  [SerializeField] private GameObject backgroundPrefab;
  private Background background;

  private Environment environment;

  #endregion


  #region Mono Behaviour

  void Awake() {
    environment = GetComponent<Environment>();
    ground = Instantiate(groundPrefab, transform).GetComponent<Ground>();
    background = Instantiate(backgroundPrefab, transform).GetComponent<Background>();
  }

  void Start() {
    ground.Initialize(environment.Size);
    background.Initialize(environment.Size);
  }

  #endregion

}
