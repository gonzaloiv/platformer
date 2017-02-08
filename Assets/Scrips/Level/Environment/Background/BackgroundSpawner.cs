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

  public void Spawn(int size) {
    for (int i = 0; i < size; i++) {
      SpawnBackground(i, backgroundPool01.PopObject());
      SpawnBackground(i, backgroundPool02.PopObject());
    }
  }

  #endregion

  #region Private Behaviour

  private void SpawnBackground(int index, GameObject background) {
    Mesh mesh = background.GetComponent<MeshFilter>().mesh;
    background.transform.Translate(index * mesh.bounds.size.x, 0, 0);
    background.SetActive(true);
  }

  #endregion
	
}