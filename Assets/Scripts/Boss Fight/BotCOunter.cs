using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BotCOunter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    private MiniScionBots botSpawner;

    public GameObject finalDialogPanel;

    // Start is called before the first frame update
    void Start()
    {
        botSpawner = GameObject.Find("MiniScionBotSpawner").GetComponent<MiniScionBots>();

        text.text = "2 X 0 = 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(botSpawner.botsCount == 12)
        {
            text.text = "2 X 1 = 2";
        }
        if(botSpawner.botsCount == 10)
        {
            text.text = "2 X 2 = 4";
        }
        if (botSpawner.botsCount == 8)
        {
            text.text = "2 X 3 = 6";
        }
        if (botSpawner.botsCount == 6)
        {
            text.text = "2 X 4 = 8";
        }
        if (botSpawner.botsCount == 4)
        {
            text.text = "2 X 5 = 10";
        }
        if (botSpawner.botsCount == 2)
        {
            text.text = "2 X 6 = 12";
        }
        if (botSpawner.botsCount == 0)
        {
            text.text = "2 X 7 = 14";
            finalDialogPanel.SetActive(true);

        }

    }
}
