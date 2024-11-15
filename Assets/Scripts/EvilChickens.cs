using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EvilChickens : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private Transform target;
    private bool coroutineRunning;

    private void OnEnable()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var temp = GameObject.FindGameObjectWithTag("Chicken");
        if (temp == null)
        {
            if (!coroutineRunning)
            {
                StartCoroutine(despawnClock());
                
            }
            return;
        }
        target = temp.transform;
        StopAllCoroutines();
        coroutineRunning = false;


        m_Agent.SetDestination(target.position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            other.GetComponent<ChickenAI>().ReturnToPool();
        }
    }

    private IEnumerator despawnClock()
    {
        Debug.Log("coroutine");
        coroutineRunning = true;
        transform.position += Vector3.up * -15 * (Time.deltaTime * 10);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
