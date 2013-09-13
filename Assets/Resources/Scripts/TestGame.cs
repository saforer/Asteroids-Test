using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TestPageType {
	None,
	TitlePage
}

public class TestGame : MonoBehaviour {
	public static TestGame instance;
	
	private TestPageType _currentPageType = TestPageType.None;
	private TestTitlePage _currentPage = null;
	
	private FStage _stage;
	
	// Use this for initialization
	void Start () {
		instance = this;
	
	
        FutileParams futileParams =  new FutileParams(false,true,true,false);

        futileParams.AddResolutionLevel(1040.0f, 1.0f, 1.0f, "");

        futileParams.origin = new Vector2(.5f, .5f);
		
		Futile.instance.Init(futileParams);
		
		Futile.atlasManager.LoadAtlas("Atlas/GameAtlas");
		
		
		
		_stage = Futile.stage;
		
		GoToPage(TestPageType.TitlePage);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GoToPage (TestPageType pageType)
	{
		if(_currentPageType == pageType) return; //we're already on the same page, so don't bother doing anything

		TestTitlePage pageToCreate = null;

		if (pageType == TestPageType.TitlePage)
		{
			pageToCreate = new TestTitlePage();
		}

		if(pageToCreate != null) //destroy the old page and create a new one
		{
			_currentPageType = pageType;	

			if(_currentPage != null)
			{
				_stage.RemoveChild(_currentPage);
			}

			_currentPage = pageToCreate;
			_stage.AddChild(_currentPage);
			_currentPage.Start();
		}
	}
}
