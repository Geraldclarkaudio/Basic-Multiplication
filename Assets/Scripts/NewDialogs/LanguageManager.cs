using SimpleJSON;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class LanguageManager : MonoBehaviour
    {
        JSONNode _langNode;
        string _langCode = "en";

        public void Awake()
        {
            //StartCoroutine(TextShow());
            StartCoroutine(TextShow2());
        }

        public string GetText(string key)
        {
            string value = _langNode?[key];
            Debug.Log(value);
            return value ?? "--missing--";
        }

        public void LanguageUpdate(string langJSON)
        {
            if (string.IsNullOrEmpty(langJSON))
            {
                return;
            }
            Debug.Log("LangUpdate()");
            _langNode = JSON.Parse(langJSON);
        }

        IEnumerator TextShow2()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "language.json");
           

            UnityWebRequest request = new UnityWebRequest(path);
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log("Damnit");
            }
            else
            {
                if (File.Exists(path))
                {
                    string langDataAsJson = File.ReadAllText(path);
                    var lang = JSON.Parse(langDataAsJson)[_langCode];
                    LanguageUpdate(lang.ToString());
                }
            }
        }

        //string path = "http://localhost/LANG/language.json";
        //public bool parsed = false;
        //private void LoadMockData()
        //{
        //    // Load Dev Language File from StreamingAssets
        //    string langFilePath = Path.Combine(Application.streamingAssetsPath, "language.json");
        //    //string langFilePath = Path.Combine("language.json");

        //    if (File.Exists(langFilePath))
        //    {
        //        string langDataAsJson = File.ReadAllText(langFilePath);
        //        var lang = JSON.Parse(langDataAsJson)[_langCode];

        //        LanguageUpdate(lang.ToString());
        //    }

        //}

        //IEnumerator TextShow()
        //{
        //    using (UnityWebRequest request = UnityWebRequest.Get(path))
        //    {
        //        yield return request.SendWebRequest();

        //        if (request.isNetworkError || request.isHttpError)
        //        {
        //            Debug.Log(request.error); // error land 
        //        }
        //        else
        //        {

        //            _langNode = JSON.Parse(request.downloadHandler.text);

        //            if (request.isDone)
        //            {
        //                parsed = true;
        //            }
        //        }
        //    }
        //}
    }
}

