using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [System.Serializable]
    public class SpawnData
    {
        public Transform _spawnTransform;
        public GameObject _objectToSpawn;
    }

    [SerializeField] private string _levelName;
    [SerializeField] private List<SpawnData> _spawns;
    [SerializeField] private PortalTrigger _portal;

    private List<GameObject> _activeObjects = new List<GameObject>();

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

    public void CheckForLevelOver()
    {
        bool levelOver = true;
        foreach (GameObject activeObject in _activeObjects)
        {
            if (activeObject != null)
            {
                levelOver = false;
            }
        }

        if (levelOver)
        {
            _portal.gameObject.SetActive(true);
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
