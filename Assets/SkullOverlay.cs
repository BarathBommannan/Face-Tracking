using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SkullOverlay : MonoBehaviour
{
    [SerializeField]
    private ARFaceManager faceManager;

    [SerializeField]
    private GameObject skullObject;

    private GameObject spawnedSkull;

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facesChanged += OnFacesChanged;
    }

    private void OnFacesChanged(ARFacesChangedEventArgs eventArgs)
    {
        if (spawnedSkull != null)
        {
            Destroy(spawnedSkull);
        }

        foreach (var face in eventArgs.added)
        {
            // Instantiate the skull object and attach it to the face
            spawnedSkull = Instantiate(skullObject, face.transform);
            spawnedSkull.transform.parent = face.transform;
            spawnedSkull.transform.localPosition = Vector3.zero; // Adjust position
            spawnedSkull.transform.localRotation = Quaternion.identity; // Adjust rotation
        }
    }
}
