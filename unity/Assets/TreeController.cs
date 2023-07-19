using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public Vector3 leaveScale = new Vector3(0f, 0f, 0f);
    public float water = 100.0f;
    // public float a

    // private
    // Start is called before the first frame update
    private List<Transform> getLeaves()
    {
        List<Transform> leaves = new List<Transform>();
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.tag == "leave")
            {
                // child.localScale = new Vector3(1f, 1f, 1f);
                leaves.Add(child);
            }
        }
        return leaves;
    }
    

    public void seedTree()
    {
        gameObject.SetActive(true);
        List<Transform> leaves = getLeaves();
        foreach (var leaf in leaves)
        {
            leaf.localScale = new Vector3(0f, 0f, 0f);

        }
        //gameObject.transform.localScale = new Vector3(leaveScale.x, leaveScale.y, leaveScale.z);
    }

    public void growTree()
    {
        List<Transform> leaves = getLeaves();
        Vector3 nextLeaveScale = new Vector3(leaveScale.x + 0.1f, leaveScale.y + 0.1f, leaveScale.z + 0.1f);
        foreach (var leaf in leaves)
        {
            
            leaf.localScale = nextLeaveScale;
            
        }
        leaveScale = nextLeaveScale;

    }

    public void waterTree()
    {

    }

    public void cutTree()
    {

    }

    public void attackTree()
    {

    }
}
