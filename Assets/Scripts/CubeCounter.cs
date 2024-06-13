/*
 * CubeCounter script is responsible for counting and displaying the number of cubes in the scene.
 * It utilizes the Singleton pattern to ensure only one instance of CubeCounter exists.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeCounter : MonoBehaviour
{
    public static CubeCounter instance;

    public TMP_Text counterText;

    private int cubeCount;

    // Awake() sets up the Singleton pattern for CubeCounter.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start() initializes the cube count and updates the display.
    private void Start()
    {
        cubeCount = 0;
        UpdateCounterText();
    }

    // IncrementCounter() increases the cube count and updates the display.
    public void IncrementCounter()
    {
        cubeCount++;
        UpdateCounterText();
    }

    // UpdateCounterText() updates the text displaying the cube count.
    private void UpdateCounterText()
    {
        counterText.text = cubeCount.ToString();
    }
}