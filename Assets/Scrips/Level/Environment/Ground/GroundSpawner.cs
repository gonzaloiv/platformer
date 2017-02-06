using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] groundPrefabs;
  private GameObjectArrayPool groundPool;

  #endregion

  #region Mono Behaviour

  void Awake () {
    groundPool = PoolManager.CreateGameObjectPool("GroundPool", groundPrefabs, 10, transform);
  }

  #endregion

  #region Public Behaviour

  public void Spawn(int size) {
    for(int i = 0; i < size; i++)
      SpawnGround(i, groundPool.PopObject());
  }

  #endregion

  #region Private Behaviour

  private void SpawnGround(int index, GameObject ground) {
    Mesh mesh = ground.GetComponent<MeshFilter>().mesh;
    ground.transform.Translate(index * mesh.bounds.size.x, 0, 0);
    ground.SetActive(true);
  }

  #endregion
	
}