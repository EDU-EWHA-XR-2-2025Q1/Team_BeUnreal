using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.Networking; 
using UnityEngine.UI; 

public class GoogleMap : MonoBehaviour 
{ 
    public RawImage MapImage; 
    string BaseURL = "https://maps.googleapis.com/maps/api/staticmap?"; 
    string URL = ""; 
    public int zoom = 14; 
    public int mapWidth = 400; 
    public int mapHeight = 400;
    //string APIKey = "자신의 API 키";

    //soo: APIKey 불러오기 추가: 시작
    string APIKey = "";

    void Awake()
    {
        LoadAPIKey();
    }

    void LoadAPIKey()
    {
        string path = Application.dataPath + "/ARoundEWHA/Out/apikey.json";
        if (System.IO.File.Exists(path))
        {
            string jsonText = System.IO.File.ReadAllText(path);
            APIKeyWrapper wrapper = JsonUtility.FromJson<APIKeyWrapper>(jsonText);
            APIKey = wrapper.GoogleMapAPIKey;
        }
        else
        {
            Debug.LogError("API 키 파일을 찾을 수 없습니다: " + path);
        }
    }

    [System.Serializable]
    class APIKeyWrapper
    {
        public string GoogleMapAPIKey;
    }

    //soo: APIKey 불러오기 추가: 끝


    // Seoul City Hall: 37.566827, 126.978113 
    double latitude = 37.566827; // 위도(남북) 
    double longitude = 126.978113; // 경도 (동서) 

    private void Start() 
    { 
        LoadMap(); 
    } 
    public void LoadMap() 
    { 
        StartCoroutine(ILoadMap()); 
    } 
    IEnumerator ILoadMap() 
    { 
        // URL form: "https://maps.googleapis.com/maps/api/staticmap?center=Z%C3%BCrich&zoom=12&size=400x400&key=YOUR_API_KEY" 
        URL = BaseURL + "center=" + latitude + "," + longitude + 
            "&zoom=" + zoom.ToString() + 
            "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString() + 
            "&key=" + APIKey + 
            "&maptype=terrain" + //terrain. hybrid, satellite, roadmap 
             // "&markers=size:mid%7Ccolor:red%7Clabel:H%7C" + latitude + "," + longitude; 
            "&markers=size:mid|color:red|label:H|" + latitude + "," + longitude; 
        print("URL : " + URL); 
        URL = UnityWebRequest.UnEscapeURL(URL); 
        print($"UnEscapeURL: {URL}"); 
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL); 
        yield return www.SendWebRequest(); 
        if (www.error == null) 
        { 
            MapImage.texture = DownloadHandlerTexture.GetContent(www); 
        } 
        else 
        { 
            print("Failed"); 
            print(www.error); 
        } 
    } 
    public void Translate_Center(double _latDiff, double _lonDiff) 
    { 
        latitude += _latDiff; 
        longitude += _lonDiff; 
    }

    //soo: SetLocation 추가
    public void SetLocation(double lat, double lon)
    {
        latitude = lat;
        longitude = lon;
        LoadMap(); // 현재 위치 기반으로 지도 다시 로드
    }
} 