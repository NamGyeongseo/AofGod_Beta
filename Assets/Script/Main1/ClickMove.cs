using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    NavMeshAgent agent;//������Ʈ�� ������ ����
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
                    transform.LookAt(cam.transform); //ĳ���� Ŭ���� ���麸�� �ϱ�
                    anim.SetBool("click", true); // ĳ���� Ŭ���� Ŭ���ִϸ��̼� ���
                    Select = true; //ĳ���� ���������� ǥ��

                    Debug.Log(hit_fir.collider.gameObject.tag + "ĳ���� ���õ�"); // ���������� �ܼ�â�� ���
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
