using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LoLSDK;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


namespace PaperKiteStudios.MultiplicationMastermind
{
    [System.Serializable]
    public class PlayerData
    {
        public int level;
    }

    public class Initializer : MonoBehaviour
    {
        private static Initializer _instance;
        public static Initializer Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("Init is null");
                }
                return _instance;
            }
        }
        public bool _init = false;
        WaitForSeconds _feedbackTimer = new WaitForSeconds(2);
        Coroutine _feedbackMethod;
        [SerializeField, Header("State Data")] PlayerData playerData;
        JSONNode _langNode;
        string _langCode = "en";
        [SerializeField] Button continueButton, newGameButton;
        [SerializeField] TextMeshProUGUI newGameText, continueText;
        public int _dataCounter = 0;
        int _totalDataCount = 2;

        void Awake()
        {

            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }


#if UNITY_EDITOR
            ILOLSDK sdk = new LoLSDK.MockWebGL();
#elif UNITY_WEBGL
		    ILOLSDK sdk = new LoLSDK.WebGL();
#elif UNITY_IOS || UNITY_ANDROID
            ILOLSDK sdk = null; // TODO COMING SOON IN V6
#endif
            LOLSDK.Init(sdk, "com.PaperKiteStudios.MultiplicationMastermind");

            LOLSDK.Instance.StartGameReceived += new StartGameReceivedHandler(StartGame);
            LOLSDK.Instance.GameStateChanged += new GameStateChangedHandler(gameState => Debug.Log(gameState));
            LOLSDK.Instance.QuestionsReceived += new QuestionListReceivedHandler(questionList => Debug.Log(questionList));
            LOLSDK.Instance.LanguageDefsReceived += new LanguageDefsReceivedHandler(LanguageUpdate);
            LOLSDK.Instance.SaveResultReceived += OnSaveResult;
            LOLSDK.Instance.GameIsReady();



#if UNITY_EDITOR
            UnityEditor.EditorGUIUtility.PingObject(this);
            LoadMockData();

#endif
        }

        private void Start()
        {
            StartCoroutine(WaitToLoad());
        }

        private void Update()
        {
            //Debug.Log("PLAYERDATA.LEVEL = " + playerData.level);
        }

        IEnumerator WaitToLoad()
        {
            yield return new WaitUntil(() => _dataCounter >= _totalDataCount);
            Helper.StateButtonInitialize<PlayerData>(newGameButton, continueButton, onload);
        }

        private void OnDestroy()
        {
#if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;
#endif
            LOLSDK.Instance.SaveResultReceived -= OnSaveResult;
        }

        public void Save()
        {
            LOLSDK.Instance.SaveState(playerData);
        }

        void OnSaveResult(bool success)
        {
            if (!success)
            {
                Debug.LogWarning("Saving not successful");
                return;
            }
        }


        void StartGame(string startGameJSON)
        {
            if (string.IsNullOrEmpty(startGameJSON))
                return;

            JSONNode startGamePayload = JSON.Parse(startGameJSON);
           // Debug.Log("StartGame()Called");

            // Capture the language code from the start payload. Use this to switch fonts
            _langCode = startGamePayload["languageCode"];

            _dataCounter++;
        }

        public void LanguageUpdate(string langJSON)
        {
            if (string.IsNullOrEmpty(langJSON))
                return;
            //Debug.Log("LangUpdate()");
            _langNode = JSON.Parse(langJSON);

            TextDisplayUpdate();
            _dataCounter++;
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

        public void onload(PlayerData loadedPlayerData)
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
                Save();
            }
            if (playerData.level == 2)
            {
                loadedPlayerData.level = 2;
                SceneManager.LoadScene("HomeBase");
                Save();
            }
            if (playerData.level == 3)
            {
                loadedPlayerData.level = 3;
                SceneManager.LoadScene("CargoShipScene");
                Save();
            }
            if (playerData.level == 4)
            {
                loadedPlayerData.level = 4;
                GameManager.Instance.cargoShipHelped = true;
                SceneManager.LoadScene("HomeBase");
                Save();
            }
            if (playerData.level == 5)
            {
                loadedPlayerData.level = 5;
                SceneManager.LoadScene("Planet1");
                Save();
            }
            if (playerData.level == 6)
            {
                loadedPlayerData.level = 6;
                GameManager.Instance.cargoShipHelped = true;
                GameManager.Instance.planet1Helped = true;
                SceneManager.LoadScene("HomeBase");
                Save();
            }
            if (playerData.level == 7)
            {
                loadedPlayerData.level = 7;
                SceneManager.LoadScene("Planet3");
                Save();
            }
            if (playerData.level == 8)
            {
                loadedPlayerData.level = 8;
                SceneManager.LoadScene("SpaceShipBuilderWithIntro");
                Save();
            }
            if (playerData.level == 9)
            {
                loadedPlayerData.level = 9;
                SceneManager.LoadScene("ScionScene");
                Save();
            }
            if (playerData.level == 10)
            {
                loadedPlayerData.level = 10;
                //GameManager.Instance.cargoShipHelped = true;
                //GameManager.Instance.planet1Helped = true;
                //GameManager.Instance.planet2Helped = true;
                SceneManager.LoadScene("HomeBase");
                Save();
            }

            if (playerData.level == 0)
            {
                continueButton.gameObject.SetActive(false);
            }



            TextDisplayUpdate();

            _init = true;
        }
#if UNITY_EDITOR
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
#endif
        

            public void SceneChanged()
            {
                Scene scene = SceneManager.GetActiveScene();

                if (scene.name == "OpeningScene")
                {
                    playerData.level = 1;
                    LOLSDK.Instance.SubmitProgress(0, 1, 10);
                }

                if (scene.name == "CargoShipScene")
                {
                    playerData.level = 3;
                    LOLSDK.Instance.SubmitProgress(0, 3, 10);
                }

                if (scene.name == "Planet1")
                {
                    playerData.level = 5;
                    LOLSDK.Instance.SubmitProgress(0, 5, 10);
                }

                if (scene.name == "Planet3")
                {
                    playerData.level = 7;
                    LOLSDK.Instance.SubmitProgress(0, 7, 10);
                }

                if (scene.name == "SpaceShipBuilderWithIntroDifferentButtonLayout")
                {
                    playerData.level = 8;
                    LOLSDK.Instance.SubmitProgress(0, 8, 10);
                }
                if (scene.name == "ScionScene")
                {
                    playerData.level = 9;
                    LOLSDK.Instance.SubmitProgress(0, 9, 10);
                }

                if (scene.name == "HomeBase")
                {

                    if (GameManager.Instance.cargoShipHelped == true && GameManager.Instance.planet1Helped == false && GameManager.Instance.planet2Helped == false)
                    {
                        playerData.level = 4;
                        LOLSDK.Instance.SubmitProgress(0, 4, 10);
                       // return;
                    }

                    if (GameManager.Instance.planet1Helped == true && GameManager.Instance.cargoShipHelped == true && GameManager.Instance.planet2Helped == false)
                    {
                        playerData.level = 6;
                        LOLSDK.Instance.SubmitProgress(0, 6, 10);
                        //return;

                    }

                    if (GameManager.Instance.planet2Helped == true && GameManager.Instance.planet1Helped == true && GameManager.Instance.cargoShipHelped == true)
                    {
                        playerData.level = 10;
                        LOLSDK.Instance.SubmitProgress(0, 10, 10);
                        //return;

                    }
                    else if(GameManager.Instance.cargoShipHelped == false)
                    {
                        playerData.level = 2;
                        LOLSDK.Instance.SubmitProgress(0, 2, 10);   
                    }
               
                }

                Save();
            }
    }
}