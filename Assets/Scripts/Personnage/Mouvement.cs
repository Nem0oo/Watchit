﻿using UnityEngine;
using System.Collections;

public class Mouvement : MonoBehaviour {
	
	private const float VITESSE = 3f;
	private const float VITESSEROTATION = 50f;
	private const float VOIEG = -0.4f;
	private const float VOIED = 0.4f;
	private const float VOIEM = 0f;
	private const float ANGLEMAXSUP = -80f;
	private const float ANGLEMAXINF = 65f;
	private float _positionCible = VOIEM;
	private float _positionActuelle = VOIEM;
	private Perso personnage;
	private GameObject minion;

	
    // Use this for initialization
    void Start()
    {
		personnage = gameObject.GetComponent ("Perso") as Perso;
		minion = transform.FindChild ("Minion").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		//Déplacement vers l'avant
		transform.Translate(Vector3.forward * VITESSE * Time.deltaTime);
		//Calcul du score
		personnage.addScore (Time.deltaTime * VITESSE);

		if ((_positionCible == VOIED && _positionActuelle == VOIEM) || (_positionCible == VOIEM && _positionActuelle == VOIEG)) 
		{
			minion.transform.Translate (Vector3.right * VOIED);
			_positionActuelle = _positionActuelle==VOIEG?VOIEM:VOIED;
		}
		else if ((_positionCible == VOIEG && _positionActuelle == VOIEM) || (_positionCible == VOIEM && _positionActuelle == VOIED)) 
		{
			minion.transform.Translate (Vector3.right * VOIEG);
			_positionActuelle = _positionActuelle == VOIED?VOIEM:VOIEG; 
		}
    }

	public void Droite()
	{
		if(_positionActuelle == VOIEM)
			_positionCible = VOIED;
		if(_positionActuelle == VOIEG)
			_positionCible = VOIEM;
	}

	public void Gauche()
	{
		if(_positionActuelle == VOIEM)
			_positionCible = VOIEG;
		if(_positionActuelle == VOIED)
			_positionCible = VOIEM;
	}

	public void BrasDroit(float degres)
	{
		GameObject brasDroit = GameObject.Find ("EpauleDroit");
		brasDroit.transform.Rotate (0f, 0f, -brasDroit.transform.rotation.z);
		brasDroit.transform.Rotate (0f, 0f, degres);
	}

	public void BrasGauche(float degres)
	{
		GameObject brasGauche = GameObject.Find ("EpauleGauche");
		brasGauche.transform.Rotate (0f, 0f, -brasGauche.transform.rotation.z);
		brasGauche.transform.Rotate (0f, 0f, degres);
	}
	
}
