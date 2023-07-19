using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateController : MonoBehaviour
{
    public TreeInteractor treeInteractor;
    public float timer = 0f;
    public float interval = 5f; // �����ϰ��� �ϴ� ����(��)
    // Start is called before the first frame update

    // List<GameObject> trees = new List<GameObject>
    void Start()
    {
        treeInteractor.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // �ð� ����� ����
        timer += Time.deltaTime;

        // 5�ʸ��� �ڵ� ����
        if (timer >= interval)
        {
            treeInteractor.AllGrow();
            timer = 0f;
        }
    }
}
