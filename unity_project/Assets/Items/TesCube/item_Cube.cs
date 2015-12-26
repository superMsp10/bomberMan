﻿using UnityEngine;
using System.Collections;

public class item_Cube : MonoBehaviour,Holdable
{

		//Holdable
		public Sprite _holdUI;
		bool _pickable;
		public int _amount;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		//Holdable
		public Sprite holdUI {
				get {
						return _holdUI; 
				}
		
		}
		public int stackSize {
				get {
						return 16; 
				}
		
		}
		public string description {
				get {
						return "<b>Hello! <color=red>My name is, </color> Cube, </b>I will be <i><color=blue>helping you</color> test!</i>"; 
				}
		
		}
		public bool pickable {
				get {
						return _pickable; 
				}
		
		}
		public int amount {
				get {
						return _amount; 
				}
				set {
						_amount = value; 
				}
		}
		public	bool  onUse ()
		{
				Debug.Log ("onUse by Cube");
				return false;
		}
		public	void  onSelect ()
		{
				Debug.Log ("onSelect by Cube");

		}
		public void  onDeselect ()
		{
				Debug.Log ("onDeselect by Cube");

		}
		public	void  onPickup ()
		{
				Debug.Log ("onPickup by Cube");

		}
		public	void  onDrop ()
		{
				Debug.Log ("onDrop by Cube");

				//		if (thisM.myPlayer != null) {
				//		playerPos = thisM.myPlayer.transform.position;
				//		
				//		GameObject p = (GameObject)Instantiate (holding.phisical.gameObject, playerPos, Quaternion.identity);
				//		tmp = p.GetComponent<pickups> ();
				//		//								tmp.thisLevel = thisM.currentLevel;
				//		tmp.pickable = false;
				//		tmp.amount = amount;
				//		Invoke ("resetPickable", tmp.resetPickup);
				//		changeHolding (null);
				//	}
		}
	
		public	void resetPick ()
		{
				Debug.Log ("ResetPick by Cube");

		}

}
