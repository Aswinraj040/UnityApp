using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    public GameObject button; // The button in the Canvas
    
    private void Awake()
    {
        Debug.Log("Hello bro i am here");
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        Debug.Log("Hello bro i am here at on enable");
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        Debug.Log("Hello bro i am at on disable");
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            // Make the button visible
            button.SetActive(true);
        }

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // Optionally, handle updated tracked images if needed
        }

        foreach (ARTrackedImage trackedImage in args.removed)
        {
            // Optionally, handle removed tracked images if needed
        }
    }

    void Start()
    {
        Debug.Log("Hello world i am here");
        // Ensure the button is initially invisible
        button.SetActive(false);
    }

    void Update()
    {
        
    }
}
