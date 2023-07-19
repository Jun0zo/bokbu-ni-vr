using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractor : MonoBehaviour
{
    public int _controllerS;

    public string spotTag = "spot"; // 가져올 객체의 태그
    public string treeTag = "tree"; // 가져올 객체의 태그
    public GameObject treeObject; // Prefab



    // Start is called before the first frame update
    public void initialize ()
    {
        Debug.Log("No!!!");
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(spotTag);

        // 가져온 객체들을 리스트로 변환
        List<GameObject> taggedObjectList = new List<GameObject>(taggedObjects);

        // 리스트를 순회하며 작업 수행
        foreach (GameObject obj in taggedObjectList)
        {
            GameObject newObject = Instantiate(treeObject, obj.transform.position, obj.transform.rotation);
            newObject.transform.SetParent(transform);

            newObject.GetComponent<TreeController>().seedTree();
            
        }
    }

    public void AllGrow()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(treeTag);
        List<GameObject> taggedObjectList = new List<GameObject>(taggedObjects);
        foreach (GameObject obj in taggedObjectList)
        {
            Debug.Log("grow!");
            obj.GetComponent<TreeController>().growTree();

        }
    }
}
