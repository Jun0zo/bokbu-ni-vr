using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraturn : MonoBehaviour
{

    public Transform target; // Ÿ�� ������Ʈ (�߽���)
    public float orbitSpeed = 10f; // ���� �ӵ�

    private Vector3 offset; // Ÿ�ٰ� ī�޶� ������ ������

    void Start()
    {
        // Ÿ�ٰ� ī�޶� ������ �ʱ� ������ ���
        offset = transform.position - target.position;
    }

    void Update()
    {
        // Ÿ���� �������� ī�޶� �������� ����
        RotateCameraAroundTarget();
    }

    void RotateCameraAroundTarget()
    {
        // ������ ����Ʈ�� ���� ȸ�� �ӵ��� ���� (Time.deltaTime�� ���)
        float rotationAngle = orbitSpeed * Time.deltaTime;

        // Ÿ�� ������ ȸ��
        transform.RotateAround(target.position, Vector3.up, rotationAngle);

        // Ÿ�� ������ ȸ���� �� �������� �����Ͽ� �׻� Ÿ���� �ٶ󺸰� ��
        transform.position = target.position + offset;
    }
}
