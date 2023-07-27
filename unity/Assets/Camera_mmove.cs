using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mmove : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��ǥ ��ġ
    public float rotationSpeed = 5f; // ī�޶� ȸ�� �ӵ�
    public float moveSpeed = 5f; // ī�޶� �̵� �ӵ�
    public Vector3 offset; // ī�޶�� ��ǥ ��ġ ������ �Ÿ��� �����ϱ� ���� ������

    private bool isRotating = true; // ī�޶� ȸ�� ���¸� Ȯ���ϱ� ���� ����
    public bool isStarted = false;

    void LateUpdate()
    {
        if (isStarted)
        {
            gameObject.GetComponent<Camera_turnn>().StopTurnning();
            // ȸ�� ó��
            if (isRotating)
            {
                Vector3 targetDirection = target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // ȸ���� �Ϸ�Ǹ� �̵� ���·� ����
                if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
                {
                    isRotating = false;
                }
            }
            else // �̵� ó��
            {
                // ���ϴ� ��ġ�� �ε巴�� �̵��ϱ� ���� ����(Interpolation)�� ���
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
                transform.position = smoothedPosition;

                // �ε巴�� ȸ���� ����(Interpolation)�Ͽ� ��ǥ�� rotation�� �����ϰ� ����
                Quaternion desiredRotation = target.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
