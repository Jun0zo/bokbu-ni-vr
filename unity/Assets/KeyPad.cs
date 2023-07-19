using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public TextMeshProUGUI ansText;
    public Animator door;
    
    private string answer = "123456";


    
    public void GetNumber(int number)
    {
        Debug.Log("goooooo");
        ansText.text += number.ToString();
    }

    public void Excute()
    {
        if (ansText.text == answer)
        {
            ansText.text = "Success";
            door.SetBool("Open", true);
            StartCoroutine("StopDoor");
            
        }
        else
        {
            ansText.text = "Invalid";
            StartCoroutine("ClearText");
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(0.5f);
        ansText.text = "";
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
        door.SetBool("Open", false);
        door.enabled = false;
    }
}
