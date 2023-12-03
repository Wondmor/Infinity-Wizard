using UnityEngine;
using UnityEngine.AI;

public class ResetNav : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform targetTransform;
    private void Start()
    {
        targetTransform = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //SetDestination(targetTransform.position);
    }

    private void SetDestination(Vector3 pos)
    {
        float agentOffset = 0.0001f;
        Vector3 agentPos = (Vector3) (agentOffset * Random.insideUnitCircle) + pos;
        navMeshAgent.SetDestination(agentPos);
    }
}
