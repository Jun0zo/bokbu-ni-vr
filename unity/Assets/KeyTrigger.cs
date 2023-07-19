using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyTrigger : MonoBehaviour
{

    public UnityEvent correctTrigger;
    // Start is called before the first frame update
    public List<GameObject> items;
    public Animator leftDoor;
    public Animator rightDoor;

    Dictionary<string, int> answer = new Dictionary<string, int>()
        {
            { "cube_1", 1 },
            { "cube_2", 1 },
            { "cube_3", 1 },
        };

    void OnTriggerEnter(Collider other)
    {
        // Dictionary<string, int> inputs;
        var inputs = new Dictionary<string, int>()
        {
            { "cube_1", 0 },
            { "cube_2", 0 },
            { "cube_3", 0 },
        };
        items.Add(other.gameObject);
        for (int i = 0; i < items.Count; i++)
        {
            foreach (KeyValuePair<string, int> entry in answer)
            {
                if (items[i].tag == entry.Key)
                {
                    inputs[entry.Key] += 1;
                }
            }
        }

        int cnt = 0;
        foreach (KeyValuePair<string, int> entry in answer)
        {   
            if (inputs[entry.Key] == answer[entry.Key])
                cnt += 1;
        }

        // Correct
        if (cnt == answer.Values.Count)
        {
            Debug.Log("Correct!@!!!!!!!!!!!!!!");
            leftDoor.SetBool("Open", true);
            rightDoor.SetBool("Open", true);
            StartCoroutine("StopDoor");
        }
        // Wrong
        else
        {
            Debug.Log("Wrong!@!!!!!!!!!!!!!!");
        }

        //door;

    }

    private void OnTriggerExit(Collider other)
    {
        items.Remove(other.gameObject);
        for (int i = 0; i < items.Count; i++)
            Debug.Log("exit : " + items[i].name);
    }

    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
        leftDoor.SetBool("Open", false);
        leftDoor.enabled = false;
        rightDoor.SetBool("Open", false);
        rightDoor.enabled = false;
    }
}
