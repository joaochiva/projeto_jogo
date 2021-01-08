using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateClient : MonoBehaviour
{

    public GameObject Client;
    public Button b_starcraft;
    
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(Client);
        b_starcraft.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

        var click = Clicaste();

        
       

        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log(click);
        }


        if (click != null)
        {
			if (click.Contains("Client"))
			{
                //var temp = GameObject.FindWithTag(click);
                FazPedido();
                //Faz aparecer o pedido
            }
           
            
        }


        




    }

	private void FazPedido()
	{
        Debug.Log("Show Pedido");
    }

	private string Clicaste()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 50);
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {


            return hit.collider.gameObject.name;
        }
        else { return "nada"; }

    }

    private void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("Começar a Craftar!");
        SceneManager.LoadScene("Craftar", LoadSceneMode.Additive);
    }
}
