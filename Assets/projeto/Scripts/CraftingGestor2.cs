using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingGestor2 : MonoBehaviour
{

    public GameObject polig_cubo;
    public GameObject polig_cilindro;
    public GameObject polig_cone;
    public GameObject polig_prism;
    public GameObject polig_esfera;
    public GameObject polig6;

    

    public List<GameObject> polig_array;
    public List<GameObject> polig_arrayobjectivos;
    //public GameObject test;
    public Button b_Getbase;
    public GameObject sv_formas;
    public Button b_cubo;
    public Button b_esfera;
    public Button b_cone;
    public Button b_cilindro;
    public Button b_prisma;
    public Button b_piramide;
    public Button b_limpar;
    public Button b_finalizar;
    public Slider s_largura;
    public Slider s_altura;
    public Slider s_profundi;
    public InputField t_admin;
    public TextMeshProUGUI t_pontuacao;
    public TextMeshProUGUI t_subirnivel;
    public TextMeshProUGUI t_tempo;

    public float scale;
    public int caso = 0;
    public int partes = 0;

    private GameObject polig_objectivo;
    private GameObject polig_criado;

    private float tempo = 60.0f;

    public Camera camera;

    public GameObject teste;
    public GameObject teste2;
    public GameObject teste3;
    public GameObject teste4;
    public GameObject teste5;




    private bool Nivel2 = false; // para ser o trigger do menu para o jogo
    private bool primeiroclick = false;
    private bool etapa1 = false;

    public bool Nivel2_rodar = false;

	// Start is called before the first frame update
	void Start()
    {
        t_admin.text = "lvl2"; //activar do menu, inicio do jogo

        polig_array.Add(polig_cubo);
        polig_array.Add(polig_cilindro);
        polig_array.Add(polig_cone);
        polig_array.Add(polig_prism);
        polig_array.Add(polig_esfera);



        polig_arrayobjectivos.Add(teste);
        polig_arrayobjectivos.Add(teste2);
        polig_arrayobjectivos.Add(teste3);
        polig_arrayobjectivos.Add(teste4);
        polig_arrayobjectivos.Add(teste5);

        //polig_arrayobjectivos.Add(polig6);

        s_altura.gameObject.SetActive(false);
        s_largura.gameObject.SetActive(false);
        s_profundi.gameObject.SetActive(false);

        t_pontuacao.gameObject.SetActive(false);
        t_subirnivel.gameObject.SetActive(false);
        t_tempo.gameObject.SetActive(false);

        sv_formas.gameObject.SetActive(false);


        b_Getbase.onClick.AddListener(TaskOnClick1);
        b_limpar.onClick.AddListener(TaskOnClick2);
        b_finalizar.onClick.AddListener(TaskOnClick3);

        b_cubo.onClick.AddListener(TaskOnClick101);
        b_esfera.onClick.AddListener(TaskOnClick102);
        b_cone.onClick.AddListener(TaskOnClick103);
        b_cilindro.onClick.AddListener(TaskOnClick104);
        b_prisma.onClick.AddListener(TaskOnClick105);
        b_piramide.onClick.AddListener(TaskOnClick106);


        //Debug.Log(GameObject.FindGameObjectsWithTag("editavel").Length);


        //polig_objectivo = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 3)], new Vector3(1, 3, 29), Quaternion.identity);

        //polig_objectivo.transform.localScale = new Vector3(UnityEngine.Random.Range(25, 100), UnityEngine.Random.Range(25, 100), 29);

        teste = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 2)], new Vector3(0, 0, 0), Quaternion.identity);
        teste.transform.transform.localScale = new Vector3(UnityEngine.Random.Range(25, 100), UnityEngine.Random.Range(25, 100), 29);

        //s_largura = GameObject.Find("Slider_largura").GetComponent<Slider>();



    }

	private void TaskOnClick106()
	{
        caso = 6;
        crafter();
        sv_formas.gameObject.SetActive(false);
        
	}

	private void TaskOnClick105()
	{
        //prisma
        caso = 5;
        crafter();
        sv_formas.gameObject.SetActive(false);
        
	}

	private void TaskOnClick104()
	{
        //cilindro
        caso = 4;
        crafter();
        sv_formas.gameObject.SetActive(false);
        
	}

	private void TaskOnClick103()
	{
        //cone
        caso = 3;
        crafter();
        sv_formas.gameObject.SetActive(false);
        
	}

	private void TaskOnClick102()
	{
        //esfera
        caso = 2;
        crafter();
        sv_formas.gameObject.SetActive(false);
        
	}

	private void TaskOnClick101()
	{
        //cubo
        caso = 1;
        crafter();
        sv_formas.gameObject.SetActive(false);
	}

	void OnEnable()
    {
        //Subscribe to the Slider Click event
        s_largura.onValueChanged.AddListener(delegate { sliderCallBack1(s_largura.value); });
        s_altura.onValueChanged.AddListener(delegate { sliderCallBack2(s_altura.value); });
        s_profundi.onValueChanged.AddListener(delegate { sliderCallBack3(s_profundi.value); });
    }

    private void TaskOnClick1()
	{
        if (primeiroclick)
        {
            if (GameObject.FindGameObjectsWithTag("editavel").Length <= 3)
            {


                Debug.Log("Começar a Craftar!");
                

                

                t_pontuacao.gameObject.SetActive(false);

                polig_criado = Instantiate(polig_array[UnityEngine.Random.Range(0, 3)], new Vector3(1, 3, 29), Quaternion.identity);
                s_altura.gameObject.SetActive(true);
                s_largura.gameObject.SetActive(true);
                if (Nivel2)
                {
                    s_profundi.gameObject.SetActive(true);
                }
                s_largura.minValue = polig_criado.transform.localScale.y;
                s_altura.minValue = polig_criado.transform.localScale.x;
                t_tempo.gameObject.SetActive(true);
                t_tempo.text = "60.0";
            }
            else
            {
                Debug.Log("Já existe um objecto!");
            }
            
        }
		else
		{
            sv_formas.gameObject.SetActive(true);
            primeiroclick = true;
            b_Getbase.interactable = false;
		}
       
        
	}

    private void TaskOnClick2()
    {
        t_pontuacao.gameObject.SetActive(false);
        t_tempo.gameObject.SetActive(false);
        b_Getbase.interactable = true;
        tempo = 60.0f;


        if (GameObject.FindGameObjectsWithTag("editavel").Length <= 3)
        {
            Debug.Log("Nada para Limpar!");

        }
        else {

			foreach (var item in GameObject.FindGameObjectsWithTag("editavel"))
			{
				if (item.name.Contains("Clone"))
				{
                    Destroy(item);
                    s_altura.gameObject.SetActive(false);
                    s_largura.gameObject.SetActive(false);
                    s_profundi.gameObject.SetActive(false);
                    return;

                }
                Debug.Log("Nada para Limpar!");
            }
            
        }
        
    }

    private void TaskOnClick3()
    {

        entrega();
        

    }

	private void entrega()
	{
        polig_objectivo = teste.transform.GetChild(partes).gameObject;
        var obj = polig_objectivo.transform.lossyScale;
        t_pontuacao.alpha = 1 ;
        t_pontuacao.gameObject.SetActive(false);

        if (Nivel2)
        {
            if (polig_criado != null)
            {
                var cri = polig_criado.transform.localScale;
                var dif = obj - cri;

                Debug.Log(dif.x);
                Debug.Log(dif.y);
                Debug.Log(dif.z);
                Debug.Log(polig_objectivo.transform.lossyScale);
                Debug.Log(polig_criado.transform.localScale);
                Debug.Log("-----------------------------------------------");
                Debug.Log(teste.transform.GetChild(0).transform.lossyScale + "Cubo base");
                Debug.Log(teste.transform.GetChild(1).transform.lossyScale + "Cubo 1");
                Debug.Log(teste.transform.GetChild(2).transform.lossyScale + "Cubo 2");

                if (dif.x < 5 && dif.y < 5 && dif.z < 5)
                {
                    if (dif.x > -5 && dif.y > -5 && dif.z > -5)
                    {

                        Debug.Log("Objecto está igual !");
                        tempo += 10f;

                        var pontos = calcPontos(dif.x, dif.y, dif.z);
                        t_pontuacao.gameObject.SetActive(true);
                        t_pontuacao.text = pontos;
                        
                        t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
                        

                    }
                    else
                    {
                        Debug.Log("Objecto não está igual !");
                        t_pontuacao.gameObject.SetActive(true);
                        t_pontuacao.text = "Objecto não está igual !";
                        t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
                    }

                }
                else
                {
                    Debug.Log("Objecto não está igual !");
                    t_pontuacao.gameObject.SetActive(true);
                    t_pontuacao.text = "Objecto não está igual !";
                    t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
                }
            }
            else
            {
                Debug.Log("Têm que criar primeiro!");
                t_pontuacao.gameObject.SetActive(true);
                t_pontuacao.text = "Têm que criar primeiro!";
                t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
            }
        }
        else
        {
            if (polig_criado != null)
            {
                var cri = polig_criado.transform.localScale;
                var dif = obj - cri;

                Debug.Log(dif.x);
                Debug.Log(dif.y);
                Debug.Log(polig_objectivo.transform.localScale);
                Debug.Log(polig_criado.transform.localScale);

                if (dif.x < 3 && dif.y < 3)
                {
                    if (dif.x > -3 && dif.y > -3)
                    {

                        Debug.Log("Objecto está igual !");
                        t_pontuacao.gameObject.SetActive(true);

                        var pontos = calcPontos(dif.x, dif.y, 0);
                        t_pontuacao.text = pontos;
                        
                    }
                    else
                    {
                        Debug.Log("Objecto não está igual !");
                        t_pontuacao.gameObject.SetActive(true);
                        t_pontuacao.text = "Objecto não está igual!";
                        t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
                    }

                }
                else
                {
                    Debug.Log("Objecto não está igual !");
                    t_pontuacao.gameObject.SetActive(true);
                    t_pontuacao.text = "Objecto não está igual!";
                    t_pontuacao.CrossFadeAlpha(0.0f, 7, true);

                }
            }
            else
            {
                Debug.Log("Têm que criar primeiro!");
                t_pontuacao.gameObject.SetActive(true);
                t_pontuacao.text = "Têm que criar primeiro!";
                t_pontuacao.CrossFadeAlpha(0.0f, 7, true);
            }
        }
    }

	private string calcPontos(float x, float y, float z)
	{
		if (x == 0 && y == 0 && z ==0)
		{
            // Perfeito
            return "100%"; 
		}
		else
		{
			if (x <= 1f && y <= 1f && z <= 1f)
			{
                //90%
                return "90%";
            }
			else if (x <= 2f && y <= 2f && z <= 2f)
			{
                //80%
                return "80%";
            }
			else if (x <= 3f && y <= 3f && z <= 3f)
			{
                //70%
                return "70%";
            }
			else if (x <= 4f && y <= 4f && z <= 4f)
			{
                //60%
                return "60%";
            }
			else
			{
                //50%   
                return "50%";
            }
		}
	}

	public void sliderCallBack1(float value)
    {
        Debug.Log("Slider Changed: " + value);
        scale = s_largura.value;
        
        foreach (var item in GameObject.FindGameObjectsWithTag("editavel"))
        {
            if (item.name.Contains("Clone"))
            {

                
				
                    item.transform.localScale = new Vector3(scale, item.transform.localScale.y, item.transform.localScale.z);
               

            }
            
        }
        
    }

    public void sliderCallBack2(float value)
    {
        Debug.Log("Slider Changed: " + value);
        scale = s_altura.value;
        foreach (var item in GameObject.FindGameObjectsWithTag("editavel"))
        {
            if (item.name.Contains("Clone"))
            {

                item.transform.localScale = new Vector3(item.transform.localScale.x,scale, item.transform.localScale.z);

            }

        }
    }

    public void sliderCallBack3(float value)
    {
        Debug.Log("Slider Changed: " + value);
        scale = s_profundi.value;
        foreach (var item in GameObject.FindGameObjectsWithTag("editavel"))
        {
            if (item.name.Contains("Clone"))
            {

                item.transform.localScale = new Vector3(item.transform.localScale.x, item.transform.localScale.y, scale);

            }

        }
    }


    void crafter() 
    {
		switch (caso)
		{
            case 1:
				if (etapa1)
				{
                    var x = teste.transform.GetChild(partes);
                    Debug.Log(teste.transform.localPosition);
                    Debug.Log(x.gameObject.name);
                    Debug.Log(x.transform.localPosition);
                    polig_criado = Instantiate(polig_array[0], x.position, Quaternion.identity);
                    //polig_criado.tag = "editavel";
                    Ac_interface();
                }
				else
				{
                    polig_criado = Instantiate(polig_array[0], new Vector3(0, 0, 0), Quaternion.identity);
                    Ac_interface();
                }
               
                break;
            case 2:
                
                    var y = teste.transform.GetChild(partes);
                    Debug.Log(teste.transform.localPosition);
                    Debug.Log(y.gameObject.name);
                    Debug.Log(y.transform.localPosition);
                    polig_criado = Instantiate(polig_array[4], y.position, Quaternion.identity);
                    //polig_criado.tag = "editavel";
                    Ac_interface();
                
                break;
            case 3:
                if (etapa1)
                {
                    var x = teste.transform.GetChild(partes);
                    Debug.Log(teste.transform.localPosition);
                    Debug.Log(x.gameObject.name);
                    Debug.Log(x.transform.localPosition);
                    polig_criado = Instantiate(polig_array[2], x.position, Quaternion.identity);
                    //polig_criado.tag = "editavel";
                    Ac_interface();
                }
                else
                {
                    polig_criado = Instantiate(polig_array[2], new Vector3(0, 0, 0), Quaternion.identity);
                    Ac_interface();
                }
                break;
            case 4:
                if (etapa1)
                {
                    var x = teste.transform.GetChild(partes);
                    Debug.Log(teste.transform.localPosition);
                    Debug.Log(x.gameObject.name);
                    Debug.Log(x.transform.localPosition);
                    polig_criado = Instantiate(polig_array[1], x.position, Quaternion.identity);
                    //polig_criado.tag = "editavel";
                    Ac_interface();
                }
                else
                {
                    polig_criado = Instantiate(polig_array[1], new Vector3(0, 0, 0), Quaternion.identity);
                    Ac_interface();
                }
                break;
            case 5:
                if (etapa1)
                {
                    var x = teste.transform.GetChild(partes);
                    Debug.Log(teste.transform.localPosition);
                    Debug.Log(x.gameObject.name);
                    Debug.Log(x.transform.localPosition);
                    polig_criado = Instantiate(polig_array[3], x.position, Quaternion.identity);
                    //polig_criado.tag = "editavel";
                    Ac_interface();
                }
                else
                {
                    polig_criado = Instantiate(polig_array[3], new Vector3(0, 0, 0), Quaternion.identity);
                    Ac_interface();
                }
                break;
            
            case 6:
                
                break;

               
			default:

                break;
		}
        
    }
    // Update is called once per frame

    void Ac_interface() 
    {
        s_altura.gameObject.SetActive(true);
        s_largura.gameObject.SetActive(true);
        if (Nivel2)
        {
            s_profundi.gameObject.SetActive(true);
        }
        s_largura.minValue = polig_criado.transform.localScale.y;
        s_altura.minValue = polig_criado.transform.localScale.x;
        t_tempo.gameObject.SetActive(true);
        t_tempo.text = "60.0";
        Debug.Log("cheguei aqui!");
    }

    private void Update()
	{

        camera.transform.LookAt(teste.transform.position);
        tempo -= Time.deltaTime;
        t_tempo.text = tempo.ToString();

        admincode(t_admin);
        
        if (Nivel2_rodar)
        {
            //Debug.Log(camera.transform.position);
            camera.transform.RotateAround(teste.transform.position, Vector3.one, 8 * Time.deltaTime);
            camera.transform.Translate(Vector3.back*100*Time.deltaTime);



            if (camera.transform.position.x < -230)
            {
                Nivel2_rodar = false;
                Destroy(polig_objectivo);
                //polig_objectivo = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 3)], new Vector3(1, 3, 29), Quaternion.identity);

                //polig_objectivo.transform.localScale = new Vector3(UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150));


                t_subirnivel.gameObject.SetActive(false);

            }
        }
        else { }

        
		
	}

	private void admincode(InputField t_admin)
	{
		switch (t_admin.text)
		{
            case "lvl2":
                Debug.LogWarning("Transformar");
                t_subirnivel.gameObject.SetActive(true);
                t_subirnivel.text = "A Transformar!";
                t_subirnivel.CrossFadeAlpha(0.0f, 7, false);
                t_admin.text = "";
                Nivel2 = true;
                Nivel2_rodar = true;
                t_tempo.gameObject.SetActive(false);

                Destroy(polig_criado);
                break;
            case "re":

				if (Nivel2)
				{
                    Debug.LogWarning("Re-Criar");
                    t_admin.text = "";
                    //Destroy(polig_objectivo);
                    //polig_objectivo = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 3)], new Vector3(1, 3, 29), Quaternion.identity);

                   // polig_objectivo.transform.localScale = new Vector3(UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150));

                    Destroy(teste);
                    teste = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 5)], new Vector3(0, 0, 0), Quaternion.identity);
                    
                    teste.transform.transform.localScale = new Vector3(UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150));
                }
				else
				{
                    Debug.LogWarning("Re-Criar");
                    t_admin.text = "";
                    //Destroy(polig_objectivo);
                    //polig_objectivo = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 3)], new Vector3(1, 3, 29), Quaternion.identity);

                    //polig_objectivo.transform.localScale = new Vector3(UnityEngine.Random.Range(50, 150), UnityEngine.Random.Range(50, 150), 29);

                    Destroy(teste);
                    teste = Instantiate(polig_arrayobjectivos[UnityEngine.Random.Range(0, 5)], new Vector3(0, 0, 0), Quaternion.identity);
                    teste.transform.transform.localScale = new Vector3(UnityEngine.Random.Range(25, 100), UnityEngine.Random.Range(25, 100), 29);
                }
                break;

            case "feit":

                polig_criado.tag = "Untagged";
                b_Getbase.interactable = true;
                s_altura.gameObject.SetActive(false);
                s_largura.gameObject.SetActive(false);
                if (Nivel2)
                {
                    s_profundi.gameObject.SetActive(false);
                }
                
                t_tempo.gameObject.SetActive(false);
                etapa1 = true;
                primeiroclick = false;
                t_admin.text = "";
                partes += 1;


                break;
            default:
                break;
		}
	}
}
