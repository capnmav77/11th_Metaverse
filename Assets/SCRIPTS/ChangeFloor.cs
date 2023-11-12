using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeFloor : MonoBehaviour
{
    public TextMeshProUGUI dispText;
    private int curr_dispNo;
    private int pressedNo;

    public void onPress()
    {
        if (dispText.text == "B")
            curr_dispNo = -1;
        else if (dispText.text == "G")
            curr_dispNo = 0;
        else
            int.TryParse(dispText.text, out curr_dispNo);
        int.TryParse(transform.name, out pressedNo);
        if (pressedNo > curr_dispNo)
        {
            StartCoroutine(changeFloor(curr_dispNo, pressedNo));
        }

        else if (pressedNo < curr_dispNo)
        {
            StartCoroutine(changeFloor(curr_dispNo, pressedNo));
        }
    }

    IEnumerator changeFloor(int curr_dispNo, int pressedNo)
    {
        if (pressedNo > curr_dispNo)
        {
            for (int i = curr_dispNo+1; i <= pressedNo; i++)
            {
                yield return new WaitForSeconds(2);
                setFloor(i);
            }
        }

        else if (pressedNo < curr_dispNo)
        {
            for (int i = curr_dispNo-1; i >= pressedNo; i--)
            {
                yield return new WaitForSeconds(2);
                setFloor(i);
            }
        }
          
    }

    private void setFloor(int i)
    {

        if (i == -1)
            dispText.text = "B";
        else if (i == 0)
            dispText.text = "G";
        else
            dispText.text = i.ToString();
    }
}
