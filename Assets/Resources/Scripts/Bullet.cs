using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bullet : FSprite {
	
	private Vector2 velocity = new Vector2();
    private float direction = 0.0f;
    private float speed = 0.0f;
	
	public bool shouldDestroy = false;
	
	private float maxAge = 0.0f;
    private float createdTime = 0.0f;
    private float destroyTime = 0.0f;
	
	
    public FNode owner;

	
	
	public Bullet (string elementName, Vector2 startPosition, float direction, float speed) : base(elementName) {
		this.direction = direction;
        this.speed = speed;
		
		CalculateVelocity(direction, speed);
	}
	
	private void CalculateVelocity (float direction, float speed) {  
			float directionRads = direction * (Mathf.PI / 180);

            this.velocity = new Vector2(speed * Mathf.Cos(directionRads), speed * Mathf.Sin(directionRads));
	}
}

