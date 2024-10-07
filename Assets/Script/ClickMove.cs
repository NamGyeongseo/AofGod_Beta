using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    NavMeshAgent agent;//에이전트의 정보를 얻음
    Animator anim;
    public Camera cam;

    public bool Select = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        OnMauseDown();
    }

    private void OnMauseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit_fir))
            {

                if (hit_fir.collider.gameObject.tag == "Charactor")
                {
                    transform.LookAt(cam.transform); //캐릭터 클릭시 정면보게 하기
                    anim.SetBool("click", true); // 캐릭터 클릭시 클릭애니메이션 재생
                    Select = true; //캐릭터 선택중임을 표시

                    Debug.Log(hit_fir.collider.gameObject.tag + "캐릭터 선택됨"); // 선택중임을 콘솔창에 출력
                }
                else if(Select && hit_fir.collider.gameObject.tag == "flor")
                {
                    Debug.Log(hit_fir.collider.gameObject.tag);
                    agent.SetDestination(hit_fir.point);
                    anim.SetBool("click", false);
                    anim.SetBool("move", true);
                    Select = false;


                }
            }
       
        }
        else if (agent.remainingDistance < 0.1f)
        {
            anim.SetBool("move", false);
        }
    }
}
