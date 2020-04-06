using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class job_bar : MonoBehaviour
{
    private RectTransform rectTransform;
    private float trabajo = 100f;
    public static float trabajando { get; set; }
    public static bool activo { get; set; }
    public static double paga { get; set; }
    public static float bug { get; set; }
    void Start()
    {
        bug = 0;
        //se oculta la barra de progreso del trabajo
        GameObject.Find("Job").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Job_bar").GetComponent<RawImage>().enabled = false;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //se le da para que se setee con la variable activo que la cambia el click
        GameObject.Find("Job").GetComponent<RawImage>().enabled = activo;
        GameObject.Find("Job_bar").GetComponent<RawImage>().enabled = activo;
        //se verifica si se esta oprimiendo alguna tecla y si esta activo
        if (Input.anyKeyDown == true && activo == true)
        {
            //se verifica que la tecla oprimida no sea ninguna del mouse
            if (Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false && Input.GetKeyDown("return") == false)
            {
                //se le resta al trabajo (variable local) el trabajando, que esta la cambia 2 scripts el de la mano derecha o izquierda y cada una le da un valor (si es la mano izquierda
                //le da un valor de 0.1 y si es la derecha le da 0.2 ya que si trabaja con las dos manos es mas eficiente
                trabajo = trabajo - trabajando - bug;
                //se setea la barra para que se vaya completando
                rectTransform.sizeDelta = new Vector2(100f, trabajo);
            }
        }
    }

    private void FixedUpdate()

    {   //si verifica si ya realizo todo el tranbajo aqui se da la recompenza al jugador por eso la variable publica paga
        if (trabajo < 0)
        {
            
            GameManager.dinero = GameManager.dinero + paga;
            
            //se setea activo para que deje de mostrar la barra de progreso
            activo = false;
            //se setea el cmd.cd para que deje de mostrar la consola
            cmd.activo = false;
            //se vuelve a reiniciar la barra para el proximo trabajo
            rectTransform.sizeDelta = new Vector2(100f, 100f);
            //se reinicia los valores para el proximo trabajo
            trabajo = 100f;
        }
    }
}
