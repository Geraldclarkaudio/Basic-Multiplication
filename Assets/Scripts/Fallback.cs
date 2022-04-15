using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    [System.Serializable]
    public class PlayerDData
    {
        public int level;
    }


    public class Fallback : MonoBehaviour
    {
        private GameObject init;
        public TMP_Text newGameText;
        public TMP_Text continueText;
        [SerializeField] Button continueButton, newGameButton;
        JSONNode _langNode;
        string _langCode = "en";
        [SerializeField, Header("State Data")] PlayerDData playerData;
        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App");
            if (init == null)
            {
                Debug.Log("init is null");
            }
            

            LoadMockData();
        }

        public void LanguageUpdate(string langJSON)
        {
            if (string.IsNullOrEmpty(langJSON))
                return;
            Debug.Log("LangUpdate()");
            _langNode = JSON.Parse(langJSON);

            TextDisplayUpdate();
        }
        public string GetText(string key)
        {
            string value = _langNode?[key];
            return value ?? "--missing--";
        }

        void TextDisplayUpdate()
        {
            newGameText.text = GetText("newGame");
            continueText.text = GetText("continueGame");
        }

        void StartGame(string startGameJSON)
        {
            if (string.IsNullOrEmpty(startGameJSON))
                return;

            JSONNode startGamePayload = JSON.Parse(startGameJSON);
            Debug.Log("StartGame()Called");

            // Capture the language code from the start payload. Use this to switch fonts
            _langCode = startGamePayload["languageCode"];
        }

        private void LoadMockData()
        {
            // Load Dev Language File from StreamingAssets

            string startDataFilePath = Path.Combine(Application.streamingAssetsPath, "startGame.json");

            if (File.Exists(startDataFilePath))
            {
                string startDataAsJSON = File.ReadAllText(startDataFilePath);
                StartGame(startDataAsJSON);
            }

            // Load Dev Language File from StreamingAssets
            string langFilePath = Path.Combine(Application.streamingAssetsPath, "language.json");
            if (File.Exists(langFilePath))
            {
                string langDataAsJson = File.ReadAllText(langFilePath);
                var lang = JSON.Parse(langDataAsJson)[_langCode];
                LanguageUpdate(lang.ToString());
            }
        }
        public void onload(PlayerDData loadedPlayerData)
        {
            // Overrides serialized state data or continues with editor serialized values.
            if (loadedPlayerData != null)
            {
                playerData = loadedPlayerData;
            }

            if (playerData.level == 1)
            {
                loadedPlayerData.level = 1;
                SceneManager.LoadScene("OpeningScene");
               
            }
            if (playerData.level == 2)
            {
                loadedPlayerData.level = 2;
                SceneManager.LoadScene("HomeBase");
                
            }
            if (playerData.level == 3)
            {
                loadedPlayerData.level = 3;
                SceneManager.LoadScene("CargoShipScene");
               
            }
            if (playerData.level == 4)
            {
                loadedPlayerData.level = 4;
                GameManager.Instance.cargoShipHelped = true;
                SceneManager.LoadScene("HomeBase");
               
            }
            if (playerData.level == 5)
            {
                loadedPlayerData.level = 5;
                SceneManager.LoadScene("Planet1");
                
            }
            if (playerData.level == 6)
            {
                loadedPlayerData.level = 6;
                GameManager.Instance.cargoShipHelped = true;
                GameManager.Instance.planet1Helped = true;
                SceneManager.LoadScene("HomeBase");
               
            }
            if (playerData.level == 7)
            {
                loadedPlayerData.level = 7;
                SceneManager.LoadScene("Planet3");
                
            }
            if (playerData.level == 8)
            {
                loadedPlayerData.level = 8;
                SceneManager.LoadScene("SpaceShipBuilderWithIntro");
                
            }
            if (playerData.level == 9)
            {
                loadedPlayerData.level = 9;
                SceneManager.LoadScene("ScionScene");
                
            }
            if (playerData.level == 10)
            {
                loadedPlayerData.level = 10;
                GameManager.Instance.cargoShipHelped = true;
                GameManager.Instance.planet1Helped = true;
                GameManager.Instance.planet2Helped = true;
                SceneManager.LoadScene("HomeBase");
                
            }

            if (playerData.level == 0)
            {
                continueButton.gameObject.SetActive(false);
            }



            TextDisplayUpdate();

           
        }

        public void SceneChanged()
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "OpeningScene")
            {
                playerData.level = 1;
            }

            if (scene.name == "CargoShipScene")
            {
                playerData.level = 3;
            }

            if (scene.name == "Planet1")
            {
                playerData.level = 5;
            }

            if (scene.name == "Planet3")
            {
                playerData.level = 7;
            }

            if (scene.name == "SpaceShipBuilderWithIntro")
            {
                playerData.level = 8;
            }
            if (scene.name == "ScionScene")
            {
                playerData.level = 9;
            }

            if (scene.name == "HomeBase")
            {

                if (GameManager.Instance.cargoShipHelped == true)
                {
                    playerData.level = 4;
                    return;
                }

                if (GameManager.Instance.planet1Helped == true)
                {
                    playerData.level = 6;
                    return;

                }

                if (GameManager.Instance.planet2Helped == true)
                {
                    playerData.level = 10;
                    return;

                }

                playerData.level = 2;
            }

           
        }
    }
}
