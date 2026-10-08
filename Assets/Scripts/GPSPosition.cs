using UnityEngine;

public class GPSPosition : MonoBehaviour
{
    public static LocationService location;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float desiredAccuracyInMeters = 1f; //How precise the location of the device is in meters
        float updateDistanceInMeters = 1f; //How far the device has to move to update position


        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters); //Starts location service updates
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        //Displaying latitude, longitude, altitude, unknown (Learning), when the data was recorded
    }

    public void Stoptracking()
    {
        Input.location.Stop();
    }
}
