using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GPSPosition : MonoBehaviour
{
    public TMP_Text latitudeText;
    public TMP_Text longitudeText;


    public static LocationService location;

    public float desiredAccuracyInMeters = 1f;
    public float updateDistanceInMeters = 1f; //These could now cause errors being declared up here?

    public List<string> latitudeList = new();
    public List<string> longitudeList = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
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
    */

    public void Stoptracking()
    {
        Input.location.Stop();

        longitudeText.text = "Test";
    }

    IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            Debug.Log("Location not enabled on device or app does not have permission to access location");

        // Starts the location service.

        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }

    public void RecordPosition()
    {
        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);

        if(Input.location.lastData.latitude != 0 && Input.location.lastData.longitude != 0)
        {
            latitudeList.Add(Input.location.lastData.latitude.ToString());
            longitudeList.Add(Input.location.lastData.longitude.ToString());

            foreach (string i in latitudeList)
            {
                latitudeText.text += "  " + i;
            }

            if(latitudeText.text == null)
            {
                latitudeText.text = "Null Text";
            }
            //("Latitude: " + latitudeList + "\n" + "Longitude: " + longitudeList);
        }
    }

    
}
