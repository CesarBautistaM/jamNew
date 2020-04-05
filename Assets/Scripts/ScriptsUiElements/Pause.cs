using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Text PanelText;
    public Text ContinueText;
    public Text Arrow;
    public InputField Codes;
    public Text ExitText;

    public GameObject flecha, lista, Panel;
    int indice = 0;

    public bool active;
    public Canvas canvas;


    public bool shotdown = false;

    void Start()
    {
        canvas = GetComponent<Canvas>();

        canvas.enabled = false;
        Arrow.enabled = false;
        // Codes.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            active = !active;
            ContinueText.text = ("Press Space To continue");
            canvas.enabled = active;
            // Codes.enabled = active;
            ExitText.enabled = false;
            // Time.timeScale = 0;

            if (this.active) GameManager.instance.PauseGame();
            else GameManager.instance.UnpauseGame();

        }

        /* Método para el Game Over
        if (ShotDown.hp == 0|| CameraOut)
         {

             PanelText.text = ("Game Over");
             ContinueText.text = ("Continue");
             ExitText.enabled = true;
             Arrow.enabled = true;
             canvas.enabled = true;
             shotdown = true;
             GameOver = 1f;
             Time.timeScale = 0;
             MenuSelector();         
         }*/

        void Predetermined()
        {
            Arrow.enabled = false;
            PanelText.text = ("Pause");
            ContinueText.text = ("Press Space To continue");
            canvas.enabled = false;
            ExitText.enabled = false;
            Time.timeScale = 1;
            shotdown = false;
            /*KO = 0f;
            ShotDown.hp = ShotDown.MaxHp;*/
        }

        void MenuSelector()
        {
            bool up = Input.GetKeyDown("up");
            bool down = Input.GetKeyDown("down");
            if (up) indice--;
            if (down) indice++;
            if (indice > lista.transform.childCount - 1) indice = 0;
            if (indice < 0) indice = lista.transform.childCount - 1;
            if (up || down) Dibujar();
            if (Input.GetKeyDown("return")) Accion();

        }

        void Dibujar()
        {
            Transform opcion = lista.transform.GetChild(indice);
            Arrow.transform.position = opcion.position;
        }

        void Accion()
        {
            Transform opcion = lista.transform.GetChild(indice);
            if (opcion.gameObject.name == "TxtExit")
            {
                Predetermined();
                print("cerrando Juego");
                SceneManager.LoadScene("Menu");
            }
            else if (opcion.gameObject.name == "TxtContinue")
            {
                SceneManager.LoadScene("NuevoJuego");
                Predetermined();
            }


        }
    }
}


