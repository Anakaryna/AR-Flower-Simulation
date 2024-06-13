/*
 * RemoveTextOnClick script hides a TextMeshProUGUI object when the user clicks or taps on the screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveTextOnClick : MonoBehaviour
{
    public TextMeshProUGUI textToBeRemoved;

    // Update() checks for user input and calls RemoveText() when the user clicks or taps on the screen.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RemoveText();
        }
    }

    // RemoveText() hides the TextMeshProUGUI object.
    private void RemoveText()
    {
        textToBeRemoved.gameObject.SetActive(false);
    }
}