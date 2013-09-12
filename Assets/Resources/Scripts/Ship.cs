using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Ship : FSprite {
	
	Vector2 orientation;
	Vector2 acceleration;
	Vector2 velocity;
	
	public Ship (string elementName) : base(elementName) {
		
		
	}
	
	public float GetFacing () {
		float shipFacing = this.rotation;
		
		int rOffset = 0;
		
		shipFacing += rOffset;
		shipFacing = 450 - (shipFacing); //Bearings to degrees
		
		return shipFacing;
		
	}
	
     private void CalculateOrientation()  {           
        float shipRads = GetFacing() * (Mathf.PI / 180);

        orientation = new Vector2(Mathf.Cos(shipRads), Mathf.Sin(shipRads));
    }
	
	
	public void HandleInput() {
		
		float shipRotationSpeed = 200;
		float shipSpeed = 20;
		float ionicpower = .05f;
		
		
		if (Input.GetKey("left"))	{          
			//update rotation then calculate orientation
			this.rotation -= (shipRotationSpeed * Time.deltaTime);
			
			CalculateOrientation();
		}
		
		if (Input.GetKey("right"))	{
			//update rotation then calculate orientation
			this.rotation += (shipRotationSpeed * Time.deltaTime);
			
			CalculateOrientation();
		}
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			
			this.acceleration = (shipSpeed * orientation * Time.deltaTime);
			
			
			this.velocity += this.acceleration;
			
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			//<InternetJanitor> Forer_: call it "ionic damping" or something that sounds cool	
			
			
			this.velocity -= this.velocity * ionicpower;
		}
		
	}
		
		public void ShipPosUpdate() {
			
			
			
			this.SetPosition(this.GetPosition() + this.velocity);
		
	}
}


