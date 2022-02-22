using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                var stoneObject = Instantiate(stonePrefab);
                var rockObject = Instantiate(rockPrefab);
                var questionObject = Instantiate(questionBoxPrefab);
                var brickObject = Instantiate(brickPrefab);

                // set the objects so they arent at the start screen
                stoneObject.transform.position = new Vector3(-10f, -10f, 0f);
                questionObject.transform.position = new Vector3(-10f, -10f, 0f);
                brickObject.transform.position = new Vector3(-10f, -10f, 0f);
                rockObject.transform.position = new Vector3(-10f, -10f, 0f);

                if (letter == 'x')
                {
                    stoneObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == '?')
                {
                    questionObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == 'b')
                {
                    brickObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == 's')
                {
                    rockObject.transform.position = new Vector3(column, row, 0f);
                }


                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
