using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ChickenPool : MonoBehaviour
{
    [SerializeField] GameObject chickenPrefab;
    [SerializeField] GameObject evilChicken;
    [SerializeField] private  int maxChickenAMount = 100;
    [SerializeField] private int stackDefaultCapacity = 100;
    private float activeChickens;

    public IObjectPool<ChickenAI> Pool { get 
        { 
        if(_pool == null)
            {
                _pool = new ObjectPool<ChickenAI>(
                    createdPoolItem,
                    OnTakeFromPool,
                    onReturendToPool,
                    onDestroyObjectPool,
                    true,
                    stackDefaultCapacity,
                    maxChickenAMount
                    );
            }
            return _pool;
        }
    }

    private IObjectPool<ChickenAI> _pool;

    private ChickenAI createdPoolItem()
    {
        var temp = Instantiate(chickenPrefab, gameObject.transform);
        ChickenAI chickenAI = temp.GetComponent<ChickenAI>();
        chickenAI.Pool = Pool;
        return chickenAI;
    }
    private void onReturendToPool(ChickenAI chickenAI)
    {
        chickenAI.gameObject.SetActive(false);
    }
    private void OnTakeFromPool(ChickenAI chickenAI)
    {
        chickenAI.gameObject.SetActive(true);
    }
    private void onDestroyObjectPool(ChickenAI chickenAI)
    {
        Destroy(chickenAI.gameObject);
    }
    public void spawnChickens()
    {
        var chicken = Pool.Get();
        chicken.transform.position=transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int chance = Random.Range(0, 10);
            {
                if (chance >= 9)
                {
                    Instantiate(evilChicken, transform);
                }
                else
                {
                    if (activeChickens >= 60)
                    {
                        var threshold = 10;
                        if (activeChickens >= 100)
                        {
                            threshold = 6;
                        }
                        var temp = Random.Range(0, 10);
                        if (temp >= threshold)
                        {
                            spawnChickens();
                        }
                    }
                    spawnChickens();
                }
            }
        }
    }
}
