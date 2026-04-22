using UnityEngine;
using System.Collections.Generic;

public class JSONLoader : MonoBehaviour
{
    public List<GPSLocation> loadedLocations = new List<GPSLocation>();

    void Start()
    {
        LoadJSONData();
    }

    void LoadJSONData()
    {
        // 1. Load JSON file
        TextAsset jsonFile = Resources.Load<TextAsset>("locations");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file missing! Create one in Assets/Resources");
            return;
        }

        // 2. Parse JSON with wrapper class
        LocationListWrapper wrapper = JsonUtility.FromJson<LocationListWrapper>(jsonFile.text);
        loadedLocations = wrapper.locations;

        // 3. Load matching textures
        foreach (GPSLocation loc in loadedLocations)
        {
            loc.photo = Resources.Load<Texture2D>(loc.historicalPhoto);
            if (loc.photo == null)
            {
                Debug.LogError($"Missing photo: {loc.historicalPhoto}");
            }
        }
    }
}