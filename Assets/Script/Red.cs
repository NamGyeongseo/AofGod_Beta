using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public float speed = 20.0f;
    public float mass = 5.0f;
    public float force = 50.0f;
    public float minDistToAvoid = 20.0f;

    float curSpeed;
    Vector3 targetPoint;
    void Start()
    {
        mass = 5.0f;
        targetPoint = new Vector3(0, 0.5f, 0); //목표지점이면서 초기값.
    }

    private void OnGUI()
    {
        GUILayout.Label("바닥을 클릭하면 이동체가 움직입니다.");
    }
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f))
        {
            targetPoint = hit.point;
        }
        //목표지점을 향하는 방향을 벡터 계산해 할당
        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();//크기가 1인 단위 벡터로 정규화
        AvoidObstacles(ref dir);

        if (Vector3.Distance(targetPoint, transform.position) < 3.0f) return;
        curSpeed = speed * Time.deltaTime;

        var rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5.0f * Time.deltaTime);

        transform.position += transform.forward * curSpeed;
    }

    public void AvoidObstacles(ref Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 8;

        if(Physics.Raycast(transform.position, transform.forward, out hit, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0.0f;

            dir = transform.forward + hitNormal * force;
        }
    }
}
