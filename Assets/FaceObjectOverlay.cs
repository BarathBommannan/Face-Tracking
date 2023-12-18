using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceObjectOverlay : MonoBehaviour
{
    [SerializeField]
    private ARFaceManager faceManager;

    [SerializeField]
    private GameObject objectToOverlay;

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facesChanged += OnFaceChanged;
    }

    private void OnFaceChanged(ARFacesChangedEventArgs eventArgs)
    {
        foreach (var face in eventArgs.added)
        {
            // Create an instance of the object to overlay
            GameObject newObject = Instantiate(objectToOverlay, face.transform);

            // Position and scale the object as needed
            newObject.transform.position = face.transform.position;
            newObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
