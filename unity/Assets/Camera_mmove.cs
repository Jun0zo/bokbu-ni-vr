using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mmove : MonoBehaviour
{
    public Transform target; // 카메라가 향할 목표 위치
    public float rotationSpeed = 5f; // 카메라 회전 속도
    public float moveSpeed = 5f; // 카메라 이동 속도
    public Vector3 offset; // 카메라와 목표 위치 사이의 거리를 조정하기 위한 오프셋

    private bool isRotating = true; // 카메라 회전 상태를 확인하기 위한 변수
    public bool isStarted = false;

    void LateUpdate()
    {
        if (isStarted)
        {
            gameObject.GetComponent<Camera_turnn>().StopTurnning();
            // 회전 처리
            if (isRotating)
            {
                Vector3 targetDirection = target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // 회전이 완료되면 이동 상태로 변경
                if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
                {
                    isRotating = false;
                }
            }
            else // 이동 처리
            {
                // 원하는 위치로 부드럽게 이동하기 위해 보간(Interpolation)을 사용
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
                transform.position = smoothedPosition;

                // 부드럽게 회전을 보간(Interpolation)하여 목표의 rotation과 동일하게 설정
                Quaternion desiredRotation = target.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
