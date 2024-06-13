/*
 * OneTimePlacement script allows content to be placed on a surface only once using Vuforia's PlaneFinderBehaviour.
 */

using UnityEngine;
using Vuforia;

public class OneTimePlacement : MonoBehaviour
{
    private bool contentPlaced = false;

    // Start() adds a listener to the PlaneFinderBehaviour's OnInteractiveHitTest event.
    private void Start()
    {
        var planeFinder = GetComponent<PlaneFinderBehaviour>();
        planeFinder.OnInteractiveHitTest.AddListener(OnInteractiveHitTest);
    }

    // OnInteractiveHitTest() disables the AnchorInputListenerBehaviour once the content is placed.
    private void OnInteractiveHitTest(HitTestResult result)
    {
        if (contentPlaced) return;
        contentPlaced = true;
        
        var anchorInputListener = GetComponent<AnchorInputListenerBehaviour>();
        if (anchorInputListener != null)
        {
            anchorInputListener.enabled = false;
        }
    }
}