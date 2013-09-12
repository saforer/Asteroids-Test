using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	public class TestTitlePage : TestPage {
		
	FSprite _background;
	FSprite _player;
	List<FSprite> BulletList = new List<FSprite>();
	List<FSprite> BulletToRemove = new List<FSprite>();
	
	Ship _ship;
	
	
	
		public TestTitlePage ()	{
		
			_background = new FSprite("background");
			AddChild(_background);
	
			_ship = new Ship("player");
			
			AddChild (_ship);
			
		
		}
	
	
	override public void HandleAddedToStage()
	{
		Futile.instance.SignalUpdate += HandleUpdate;
		base.HandleAddedToStage();
	}

	override public void HandleRemovedFromStage()
	{
		Futile.instance.SignalUpdate -= HandleUpdate;
		base.HandleRemovedFromStage();
	}

	
		void HandleUpdate () {
			_ship.HandleInput();
			_ship.ShipPosUpdate();
		
		
			BulletUpdate();
		
		}
	

	
	
		private void BulletUpdate() {
	
		foreach (FSprite bullet in BulletList) {
	    	bullet.y+=20;
							
		    if (bullet.y >= Futile.screen.halfHeight||bullet.y <= -Futile.screen.halfHeight||bullet.x >= Futile.screen.halfWidth ||bullet.x <= -Futile.screen.halfWidth) {
		      BulletToRemove.Add(bullet);
		    }
		  }	
									
		  foreach (FSprite bullet in BulletToRemove) {
		    BulletList.Remove(bullet);
		    RemoveChild (bullet);	
		  }

                   BulletToRemove.Clear();
		}
	

	
	}