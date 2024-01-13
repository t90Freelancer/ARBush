using UnityEngine.XR.ARFoundation;
using UnityEngine;
using System;

public class PlayfapCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefap;
    [SerializeField] private Vector3 prefapOffset;

    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var image in obj.added)
        {
            dragon = Instantiate(dragonPrefap, image.transform);
            dragon.transform.position += prefapOffset;
        }
    }
}
