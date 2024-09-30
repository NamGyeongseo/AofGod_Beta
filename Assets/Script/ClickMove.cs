using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    NavMeshAgent agent;//에이전트의 정보를 얻음
    Animator anim;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))

            {
                agent.SetDestination(hit.point);
                anim.SetBool("move", true);

            }
        }
        else if(agent.remainingDistance < 0.1f)
        {
            anim.SetBool("move", false);
        }
    }
}
