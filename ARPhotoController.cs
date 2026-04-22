using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARPhotoController : MonoBehaviour
{
    [Header("AR Components")]
    public GameObject photoPrefab;    // Quad with unlit material
    private GameObject currentPhoto;  // Active photo instance
    private ARRaycastManager arRaycastManager;

    [Header("UI References")]
    public Slider opacitySlider;
    public Text locationText;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        opacitySlider.onValueChanged.AddListener(UpdateOpacity);
    }

    public void ShowPhoto(Texture2D photo, string locationName)
    {
        // Remove old photo
        if (currentPhoto != null) Destroy(currentPhoto);

        // Find AR plane
        Vector2 screenCenter = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        if (arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            // Create new photo object
            currentPhoto = Instantiate(photoPrefab, 
                hits[0].pose.position, 
                hits[0].pose.rotation);
            
            // Set texture and UI
            currentPhoto.GetComponent<Renderer>().material.mainTexture = photo;
            locationText.text = locationName;
        }
    }

    void UpdateOpacity(float value)
    {
        if (currentPhoto != null)
        {
            Color color = currentPhoto.GetComponent<Renderer>().material.color;
            color.a = value;
            currentPhoto.GetComponent<Renderer>().material.color = color;
        }
    }
}