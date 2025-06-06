using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.Android;

// https://docs.unity3d.com/ScriptReference/LocationService.Start.html 
public class GPS : MonoBehaviour 
{ 
    public double latitude, longitude, altitude, horizontalAccuracy, verticalAccuracy, timestamp; 
    int waitTime = 20; 
    bool keepAlive = true; 
    // Debug 
    [Range(10, 150)] 
    public int fontSize = 30; 
    public Color color = new Color(.0f, .0f, .0f, 1.0f); 
    public float width, height; 
    string debugMessage = ""; 
    int counter; 

    void Start() 
    {
        ///////////////////// 안드로이드 관련 추가
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif
        /////////////////////

        Get_GPS();
    } 

    public void Get_GPS() 
    { 
        StartCoroutine(IGet_GPS()); 
    } 

    public void Stop_GPS() 
    { 
        Input.location.Stop(); 
    } 

    IEnumerator IGet_GPS() 
    { 
        debugMessage = ""; 
        if (!Input.location.isEnabledByUser) 
        { 
            debugMessage = "Location not enabled on device or app does not have permission to access location"; 
            print(debugMessage); 
            yield break; 
        } 
        // Start location service  
        float desiredAccuracyInMeters = 10f; 
        float updateDistanceInMeters = 10f; 
        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters); 
        // Waits until the location service initializes 
        int maxWait = waitTime; 
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
        { 
            yield return new WaitForSeconds(1); 
            maxWait--; 
        } 
        // If the service didn't initialize in 20 seconds this cancels location service use. 
        if (maxWait < 1) 
        { 
            debugMessage = "Timed out"; 
            print(debugMessage); 
            yield break; 
        } 
        // If the connection fails cancel location service 
        if (Input.location.status == LocationServiceStatus.Failed) 
        { 
            debugMessage = "Unable to determine device location"; 
            print(debugMessage); 
            yield break; 
        } 
        else 
        { 
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window. 
            latitude = Input.location.lastData.latitude; 
            longitude = Input.location.lastData.longitude; 
            altitude = Input.location.lastData.altitude; 
            horizontalAccuracy = Input.location.lastData.horizontalAccuracy; 
            verticalAccuracy = Input.location.lastData.verticalAccuracy; 
            timestamp = Input.location.lastData.timestamp; 
            counter++; 
            debugMessage = 
                "Latitude=" + latitude + 
                "\nLongitude=" + longitude + 
                "\nAltitude=" + altitude + 
                "\nHorizontal Accuracy=" + horizontalAccuracy + 
                "\nVertical Accuracy=" + verticalAccuracy + 
                "\nTimeStamp=" + timestamp + 
                "\nCounter=" + counter; 
            print(debugMessage); 
        } 
        while (keepAlive) 
        { 
            latitude = Input.location.lastData.latitude; 
            longitude = Input.location.lastData.longitude; 
            altitude = Input.location.lastData.altitude; 
            horizontalAccuracy = Input.location.lastData.horizontalAccuracy; 
            verticalAccuracy = Input.location.lastData.verticalAccuracy; 
            timestamp = Input.location.lastData.timestamp; 
            counter++; 
            debugMessage = 
                "Latitude=" + latitude + 
                "\nLongitude=" + longitude + 
                "\nAltitude=" + altitude + 
                "\nHorizontal Accuracy=" + horizontalAccuracy + 
                "\nVertical Accuracy=" + verticalAccuracy + 
                "\nTimeStamp=" + timestamp + 
                "\nCounter=" + counter; 
            print(debugMessage);
            print("keepAlive 상태: " + keepAlive);
            yield return new WaitForSeconds(10.0f);

            // soo: 현재 위치를 GoogleMap.cs에 전달
            FindObjectOfType<GoogleMap>().SetLocation(latitude, longitude);

            yield return new WaitForSeconds(10.0f);

        } 
    } 

    void OnGUI() 
    { 
        GUIStyle style = new GUIStyle(); 
        style.fontSize = fontSize; 
        style.normal.textColor = color; //new Color(.0f, .0f, .0f, 1.0f); 
        style.alignment = TextAnchor.UpperLeft; 
        GUI.Label(new Rect(0, 0, width, height), debugMessage, style); 
    }


} 