using System;
using AddressablesTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DanGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI[] musicNumberTexts;
    [SerializeField] private TextMeshProUGUI[] musicTexts;
    [SerializeField] private TextMeshProUGUI[] levelTexts1, levelTexts2;
    
    [SerializeField] private TextMeshProUGUI soulText, soulGoldText;
    [SerializeField] private TextMeshProUGUI[] judgeTitleTexts;
    [SerializeField] private TextMeshProUGUI[] judgeContentTexts1, judgeContentTexts2, judgeContentTexts3;
    [SerializeField] private TextMeshProUGUI[] judgeContentGoldTexts1, judgeContentGoldTexts2, judgeContentGoldTexts3;
    
    [SerializeField] private Image[] musicNumberImages;
    [SerializeField] private Color[] musicNumberColors;
    [SerializeField] private Image[] difficultyImages1, difficultyImages2;
    [SerializeField] private Sprite[] difficultySprites;
    [SerializeField] private Image[] musicBackImages;
    [SerializeField] private Sprite[] musicBackSprites;
    [SerializeField] private Image titleBackImage;
    [SerializeField] private Color[] titleBackColors;
    [SerializeField] private Image mainBackImage;
    [SerializeField] private Color[] mainBackColors;
    
    private CSVLoader csvLoader;

    private void Awake()
    {
        string appDataPath = Application.dataPath;
        string csvPath = appDataPath + "/Dan.csv";
        Debug.Log(csvPath);
        csvLoader = new CSVLoader(csvPath);
    }

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        csvLoader.Load();
        
        titleText.text = csvLoader.csvData[0, 0];
        int kind = int.Parse(csvLoader.csvData[0, 1]);
        titleBackImage.color = titleBackColors[kind];
        mainBackImage.color = mainBackColors[kind];

        musicNumberTexts[0].text = "1st";
        musicNumberTexts[1].text = "2nd";
        musicNumberTexts[2].text = "3rd";

        musicNumberImages[0].color = musicNumberColors[0];
        musicNumberImages[1].color = musicNumberColors[1];
        musicNumberImages[2].color = musicNumberColors[2];
        for (int y = 0; y < 3; y++)
        {
            int yIndex = y + 1;
            int musicBackIndex = int.Parse(csvLoader.csvData[yIndex, 0]);
            musicBackImages[y].sprite = musicBackSprites[musicBackIndex];
            int level1 = int.Parse(csvLoader.csvData[yIndex, 1]);
            int difficulty1 = int.Parse(csvLoader.csvData[yIndex, 2]);
            int level2 = int.Parse(csvLoader.csvData[yIndex, 3]);
            int difficulty2 = int.Parse(csvLoader.csvData[yIndex, 4]);
            levelTexts1[y].text = "★" + level1.ToString();
            levelTexts2[y].text = "★" + level2.ToString();
            difficultyImages1[y].sprite = difficultySprites[difficulty1];
            difficultyImages2[y].sprite = difficultySprites[difficulty2];
            musicTexts[y].text = csvLoader.csvData[yIndex, 5];
        }
        
        soulText.text = csvLoader.csvData[4, 0];
        soulGoldText.text = csvLoader.csvData[4, 1];

        for (int y = 0; y < 3; y++)
        {
            int yIndex = y + 5;
            judgeTitleTexts[y].text = csvLoader.csvData[yIndex, 0];
            if (y == 0)
            {
                judgeContentTexts1[0].text = csvLoader.csvData[yIndex, 1];
                judgeContentGoldTexts1[0].text = csvLoader.csvData[yIndex, 2];
                judgeContentTexts1[1].text = csvLoader.csvData[yIndex, 3];
                judgeContentGoldTexts1[1].text = csvLoader.csvData[yIndex, 4];
                judgeContentTexts1[2].text = csvLoader.csvData[yIndex, 5];
                judgeContentGoldTexts1[2].text = csvLoader.csvData[yIndex, 6];
            }else if (y == 1)
            {
                judgeContentTexts2[0].text = csvLoader.csvData[yIndex, 1];
                judgeContentGoldTexts2[0].text = csvLoader.csvData[yIndex, 2];
                judgeContentTexts2[1].text = csvLoader.csvData[yIndex, 3];
                judgeContentGoldTexts2[1].text = csvLoader.csvData[yIndex, 4];
                judgeContentTexts2[2].text = csvLoader.csvData[yIndex, 5];
                judgeContentGoldTexts2[2].text = csvLoader.csvData[yIndex, 6];
            }
            else if (y == 2)
            {
                judgeContentTexts3[0].text = csvLoader.csvData[yIndex, 1];
                judgeContentGoldTexts3[0].text = csvLoader.csvData[yIndex, 2];
                judgeContentTexts3[1].text = csvLoader.csvData[yIndex, 3];
                judgeContentGoldTexts3[1].text = csvLoader.csvData[yIndex, 4];
                judgeContentTexts3[2].text = csvLoader.csvData[yIndex, 5];
                judgeContentGoldTexts3[2].text = csvLoader.csvData[yIndex, 6];
            }
        }
        
        //画像を保存
        ScreenCapture.CaptureScreenshot("Dan.png");
        Debug.Log("Dan.pngを保存しました。");
        Application.Quit();
    }
}
