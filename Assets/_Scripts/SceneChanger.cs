/*
Author: Andres Mrad (Q-ro)
Date: Saturday 04/April/2020 @ 15:40:33
Description:  Handles the loading and unloading of scenes inside the game 
*/

using UnityEngine.SceneManagement;

public class SceneChanger
{
    public void SetScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
