using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    public class SpawnData
    {
        public Transform _spawnTransform;
        public GameObject _objectToSpawn;
    }

    [SerializeField] private string _levelName;
    [SerializeField] private List<SpawnData> _spawns;

    private List<GameObject> _activeObjects;

    public void StartLevel()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        _activeObjects.Clear();
        foreach(SpawnData spawnData in _spawns)
        {
            GameObject go = Instantiate(spawnData._objectToSpawn, this.transform);
            go.transform.position = spawnData._spawnTransform.position;
            go.SetActive(true);

            _activeObjects.Add(go);
        }
    }

    public void FinishLevel()
    {
        foreach(GameObject activeObject in _activeObjects)
        {
            if(activeObject != null)
            {
                Destroy(activeObject);
            }
        }

        GameManager.Instance.OnLevelComplete();
    }
}
