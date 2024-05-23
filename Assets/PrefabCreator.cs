using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject dragon;
    private ARTrackedImageManager ARTrackedImageManager;

    private void OnEnable()
    {
        ARTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        ARTrackedImageManager.trackedImagesChanged += OnImageChanged;

    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage image in obj.added)
        {
            dragon = Instantiate(dragonPrefab,image.transform);
            dragon.transform.position += prefabOffset;
        }
    }

}
