using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GoogleMap : MonoBehaviour 
{ 
    public RawImage MapImage; 
    string BaseURL = "https://maps.googleapis.com/maps/api/staticmap?"; 
    string URL = ""; 
    public int zoom = 17; 
    public int mapWidth = 400; 
    public int mapHeight = 400;
    //string APIKey = "자신의 API 키";

    //soo: APIKey 불러오기 추가: 시작
    string APIKey = "AIzaSyC6gSVrUXZKqqTNknzQaUuYqzqccB855HE";

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
        // 씬 이름에 따라 위치 설정

        //EccToFront 씬 : 지도 위치 = 이화여대 정문 셔틀정류소
        if (SceneManager.GetActiveScene().name == "EccToFront")
        {
            latitude = 37.560423;
            longitude = 126.945979;
        }
        //EngToSci1 씬 : 지도 위치 = 이화여대 종합과학관
        else if (SceneManager.GetActiveScene().name == "EngToSci1")
        {
            latitude = 37.564427;
            longitude = 126.947747;
        }
        //Pos1ToPos2 씬 : 지도 위치 = 이화여대 포스코관
        else if (SceneManager.GetActiveScene().name == "Pos1ToPos2")
        {
            latitude = 37.563679;
            longitude = 126.946819;
        }
        //Pos2ToEcc 씬 : 지도 위치 = 이화여대 후윳길
        else if (SceneManager.GetActiveScene().name == "Pos2ToEcc")
        {
            latitude = 37.560979;
            longitude = 126.945274;
        }
        //Sci1ToSci2 씬 : 지도 위치 = 이화여대 종합과학관
        else if (SceneManager.GetActiveScene().name == "Sci1ToSci2")
        {
            latitude = 37.564427;
            longitude = 126.947747;
        }
        //Sci2ToPos1 씬 : 지도 위치 = 이화여대 포스코관
        else if (SceneManager.GetActiveScene().name == "Sci2ToPos1")
        {
            latitude = 37.563679;
            longitude = 126.946819;
        }



        //FrontToEcc 씬 : 지도 위치 = 이화여대 후윳길
        if (SceneManager.GetActiveScene().name == "FrontToEcc")
        {
            latitude = 37.560979;
            longitude = 126.945274;
        }
        //Sci1ToEng 씬 : 지도 위치 = 이화여대 아산공학관
        else if (SceneManager.GetActiveScene().name == "Sci1ToEng")
        {
            latitude = 37.566644;
            longitude = 126.948449;
        }
        //Pos2ToPos1 씬 : 지도 위치 = 이화여대 포스코관
        else if (SceneManager.GetActiveScene().name == "Pos2ToPos1")
        {
            latitude = 37.563679;
            longitude = 126.946819;
        }
        //EccToPos2 씬 : 지도 위치 = 이화여대 포스코관
        else if (SceneManager.GetActiveScene().name == "EccToPos2")
        {
            latitude = 37.563679;
            longitude = 126.946819;
        }
        //Sci2ToSci1 씬 : 지도 위치 = 이화여대 종합과학관
        else if (SceneManager.GetActiveScene().name == "Sci2ToSci1")
        {
            latitude = 37.564427;
            longitude = 126.947747;
        }
        //Pos1ToSci2 씬 : 지도 위치 = 이화여대 종합과학관
        else if (SceneManager.GetActiveScene().name == "Pos1ToSci2")
        {
            latitude = 37.564427;
            longitude = 126.947747;
        }

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