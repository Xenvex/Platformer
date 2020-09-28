using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    //Blocks and Stuff
    public GameObject Rock;
    public GameObject Brick;
    public GameObject QuestionBox;
    public GameObject Stone;

    //For UI Stuff
    public TextMeshProUGUI Mario;
    public TextMeshProUGUI World;
    public TextMeshProUGUI Time;

    private float score = 0;
    private float world = 1;
    private float level = 1;
    private float time = 300;
    private float inc = 0;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }

    void Update()
    {

        //Time Stuff
        if(inc == 240)
        {
            inc = 0;
            time--;
        }
        else
        {
            inc++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Destroy(gameObject);
            Debug.Log(gameObject.name);
        }

        //UI stuff
        Mario.text = ""+score;
        World.text = world + " - " + level;
        Time.text = ""+time;
    }

    //translates the parser
    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column, row, 0));
                    column++;//Moving through the columns(This determines the direction things spawn in)
                }
                row--;//Moving through the rows
            }

            sr.Close();
        }
    }

    //Interpreting the level parser, and spawns objects accordingly
    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': //Debug.Log("Spawn Brick");
                ToSpawn = Brick;
                break;
            case '?': //Debug.Log("Spawn QuestionBox");
                ToSpawn = QuestionBox;
                break;
            case 'x': //Debug.Log("Spawn Rock");
                ToSpawn = Rock;
                break;
            case 's': //Debug.Log("Spawn Rock");
                ToSpawn = Stone;
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
