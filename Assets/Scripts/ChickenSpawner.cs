using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    private ChickenPool _pool;
    void Start()
    {
        _pool=gameObject.GetComponent<ChickenPool>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("SpawnCickens"))
        {
            _pool.spawnChickens();
        }
    }
}
