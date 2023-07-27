using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraturn : MonoBehaviour
{

    public Transform target; // 타겟 오브젝트 (중심점)
    public float orbitSpeed = 10f; // 공전 속도

    private Vector3 offset; // 타겟과 카메라 사이의 오프셋

    void Start()
    {
        // 타겟과 카메라 사이의 초기 오프셋 계산
        offset = transform.position - target.position;
    }

    void Update()
    {
        // 타겟을 기준으로 카메라를 원형으로 돌림
        RotateCameraAroundTarget();
    }

    void RotateCameraAroundTarget()
    {
        // 프레임 레이트에 따라 회전 속도를 조정 (Time.deltaTime을 사용)
        float rotationAngle = orbitSpeed * Time.deltaTime;

        // 타겟 주위를 회전
        transform.RotateAround(target.position, Vector3.up, rotationAngle);

        // 타겟 주위를 회전한 후 오프셋을 유지하여 항상 타겟을 바라보게 함
        transform.position = target.position + offset;
    }
}
