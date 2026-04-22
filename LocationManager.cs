using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LocationManager : MonoBehaviour
{
    [Header("References")]
    public JSONLoader jsonLoader;
    public ARPhotoController arPhotoController;

    [Header("Settings")]
    public float updateInterval = 1f; // GPS update rate

    private float lastUpdateTime;

    void Start()
    {
        // Start GPS service with high accuracy
        Input.location.Start(1f, 1f);
    }

    void Update()
    {
        // Update at intervals to save battery
        if (Time.time - lastUpdateTime > updateInterval)
        {
            lastUpdateTime = Time.time;
            CheckLocation();
        }
    }

    void CheckLocation()
    {
        if (Input.location.status != LocationServiceStatus.Running) return;

        // Get current GPS coordinates
        double currentLat = Input.location.lastData.latitude;
        double currentLon = Input.location.lastData.longitude;

        // Check against all locations
        foreach (GPSLocation loc in jsonLoader.loadedLocations)
        {
            if (IsWithinRadius(currentLat, currentLon, loc.latitude, loc.longitude, loc.radius))
            {
                arPhotoController.ShowPhoto(loc.photo, loc.locationName);
                return; // Show first matching location
            }
        }
    }

    bool IsWithinRadius(double lat1, double lon1, double lat2, double lon2, float radius)
    {
        // Haversine formula implementation
        const float R = 6371000; // Earth radius in meters
        
        double latRad1 = lat1 * Mathf.Deg2Rad;
        double latRad2 = lat2 * Mathf.Deg2Rad;
        double deltaLat = (lat2 - lat1) * Mathf.Deg2Rad;
        double deltaLon = (lon2 - lon1) * Mathf.Deg2Rad;

        double a = Mathf.Sin((float)deltaLat / 2) * Mathf.Sin((float)deltaLat / 2) +
                   Mathf.Cos((float)latRad1) * Mathf.Cos((float)latRad2) *
                   Mathf.Sin((float)deltaLon / 2) * Mathf.Sin((float)deltaLon / 2);
                   
        double c = 2 * Mathf.Atan2(Mathf.Sqrt((float)a), Mathf.Sqrt((float)(1 - a)));
        double distance = R * c;

        return distance <= radius;
    }
}