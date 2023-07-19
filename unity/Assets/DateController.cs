using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateController : MonoBehaviour
{
    public TreeInteractor treeInteractor;
    public float timer = 0f;
    public float interval = 5f; // 실행하고자 하는 간격(초)
    // Start is called before the first frame update

    // List<GameObject> trees = new List<GameObject>
    void Start()
    {
        treeInteractor.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 시간 경과를 추적
        timer += Time.deltaTime;

        // 5초마다 코드 실행
        if (timer >= interval)
        {
            treeInteractor.AllGrow();
            timer = 0f;
        }
    }
}
