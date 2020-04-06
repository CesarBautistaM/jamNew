/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 17:01:44
Description:  Shutsdown the game and exist the unity application 
*/

using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
}
