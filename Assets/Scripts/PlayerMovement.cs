using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public ParticleSystem clickParticle;

    public new Camera camera;

   

    // Update is called once per frame
    private void Update()
    {
        HandleMoveToPoint();
    }

    private void HandleMoveToPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
                if (navMeshAgent.CalculatePath(hit.point, new NavMeshPath()))
                    MoveToPoint(hit);
        }
    }

    private void MoveToPoint(RaycastHit hit)
    {
        navMeshAgent.SetDestination(hit.point);
        MakeClickAnimation(hit);
    }

    private void MakeClickAnimation(RaycastHit hit)
    {
        clickParticle.transform.position = hit.point + new Vector3(0, 0.001f, 0);
        clickParticle.Play();
    }
}