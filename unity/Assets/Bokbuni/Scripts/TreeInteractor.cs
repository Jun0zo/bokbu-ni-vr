using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractor : MonoBehaviour
{
    public int _controllerS;

    public string spotTag = "spot"; // ������ ��ü�� �±�
    public string treeTag = "tree"; // ������ ��ü�� �±�
    public GameObject treeObject; // Prefab



    // Start is called before the first frame update
    public void initialize ()
    {
        Debug.Log("No!!!");
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(spotTag);

        // ������ ��ü���� ����Ʈ�� ��ȯ
        List<GameObject> taggedObjectList = new List<GameObject>(taggedObjects);

        // ����Ʈ�� ��ȸ�ϸ� �۾� ����
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
