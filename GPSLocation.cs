using UnityEngine;

[System.Serializable]
public class GPSLocation
{
    public string locationName;     // Name of landmark
    public double latitude;         // GPS latitude
    public double longitude;        // GPS longitude
    public float radius;            // Trigger radius in meters
    public string historicalPhoto;  // Filename of image
    [System.NonSerialized] public Texture2D photo; // Actual texture (not stored in JSON)
}