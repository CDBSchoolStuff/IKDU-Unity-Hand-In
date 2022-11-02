using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    float velocity;
    Vector3 Vector;

    public string playerName;
    private int playerLevel = 1;
    private int points;
    private int levelUpPoints = 10;

    [SerializeField] private bool enableDebugging; //This bool is used to enable/disable the printing of debugging values to the console.

    void Start()
    {
        Debugging("playerLevel");
        Debugging("points");
    }

    void Update()
    {
        Vector = transform.localPosition;
        //Vector.y += Input.GetAxis("Jump") * Time.deltaTime * 20;  
        Vector.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        Vector.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vector;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object") //If collided object have the tag "Object"
        {
            points = points + 1; //Increase points with 1.

            playerLevel = ComputeLevel(points); //Calls the 'ComputeLevel' method to calculate the level based on amount of points and sets the 'playerLevel' variable to that value.

            Debugging("points");
            Destroy(other.gameObject); //Destroy the collided object.
        }
    }

    //Calculates the level based on amount of points.
    int ComputeLevel(int point)
    {
        float playerLevelFloat = playerLevel; //Converts playerLevel int into a float.
        float levelUpPointsFloat = levelUpPoints; //Converts levelUpPoints int into a float.
        float requiredPoints = ((1 + (playerLevelFloat / 10)) * levelUpPointsFloat); //Calculates the amount of points required to level-up.

        Debug.Log("computedPoints = " + requiredPoints);

        if (points >= requiredPoints) //Checks you have the required amount of points to level-up.
        {
            int computedLevel = playerLevel + 1; //Increases the level counter by 1.
            points = 0; //Resets your points to 0.

            Debugging("playerLevel"); //Calls 'Debugging' function to write the playerLevel to console.
            return computedLevel; //Returns the computed level.
        }
        else //This 'else' statement just returns the 'playerLevel' with no alterations since we did not have the required amount of points.
        {
            int computedLevel = playerLevel;
            return computedLevel;
        }
    }



    //This function is responsible for printing values to the console. It is enabled/disabled by the "enableDebug" bool.
    void Debugging(string type)
    {
        if (enableDebugging == true && type == "playerLevel") //Only prints to console if 'enableDebugging' is true and the received string equels "playerLevel".
        {
            Debug.Log("Player Level = " + playerLevel); //Prints the player level to console
        }

        if (enableDebugging == true && type == "points") //Only prints to console if 'enableDebugging' is true and the received string equels "points".
        {
            Debug.Log("Points = " + points); //Prints the player level to console
        }
    }
}
