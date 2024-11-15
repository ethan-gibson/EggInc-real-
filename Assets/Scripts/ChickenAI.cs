using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class ChickenAI : MonoBehaviour
{
	private GameObject chosenCoop;
	[SerializeField] NavMeshAgent chickenAgent;

	public IObjectPool<ChickenAI> Pool { get; set; }
	private void OnEnable()
	{
		chickenAgent = GetComponent<NavMeshAgent>();
		var Coops = GameObject.FindGameObjectsWithTag("ChickenCoop");
		chosenCoop = Coops[Random.Range(0, Coops.Length)];
	}
    private void Update()
    {
        if (chosenCoop != null)
		{
            chickenAgent.SetDestination(chosenCoop.transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject==chosenCoop)
		{
			GameManager.Instance.AddToChickenCount();
			gameObject.SetActive(false);
			ReturnToPool();
		}
    }
	public void ReturnToPool()
	{
        Pool.Release(this);
    }
}
