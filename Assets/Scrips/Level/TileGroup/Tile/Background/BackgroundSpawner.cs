using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] backgroundPrefabs01;
  [SerializeField] private GameObject[] backgroundPrefabs02;
  private GameObjectArrayPool backgroundPool01;
  private GameObjectArrayPool backgroundPool02;

  #endregion

  #region Mono Behaviour

  void Awake () {
    backgroundPool01 = PoolManager.CreateGameObjectPool("BackgroundPool01", backgroundPrefabs01, 10, transform);
    backgroundPool02 = PoolManager.CreateGameObjectPool("BackgroundPool02", backgroundPrefabs02, 10, transform);
  }

  #endregion

  #region Public Behaviour

  public void Spawn(float position) {
    SpawnBackground(backgroundPool01.PopObject(), position);
    SpawnBackground(backgroundPool02.PopObject(), position);
  }

  #endregion

  #region Private Behaviour

  private void SpawnBackground(GameObject background, float position) {
    background.transform.Translate(new Vector3(position, 0, 0));
    background.SetActive(true);
  }

  #endregion
	
}