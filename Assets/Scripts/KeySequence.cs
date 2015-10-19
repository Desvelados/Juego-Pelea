﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeySequence {

	public delegate void HandleCallback(KeySequence pSequence); 
	List<string> mKeyList = new List<string>(); 
	int mProgressIndex = 0 ; 
	HandleCallback mHCB = null;

	public KeySequence(HandleCallback pCallbackFunction)
	{
		mHCB = pCallbackFunction;
	}
	public void AddKey2Sequence(string pKeyStr)
	{
	    mKeyList.Add(pKeyStr);
	}
	public void  Update()
	{
		if(mKeyList.Count==0)
		{
		    return ;
		}
		if(Input.GetKey(mKeyList[mProgressIndex]))
		{
			mProgressIndex++;
			if(mProgressIndex >= mKeyList.Count)
		    {
		        if(mHCB!=null)
		        {
		            mProgressIndex=0;
		            mHCB(this);
		        }
		    }
		}
		else
		{
		    mProgressIndex=0;
		}
	}
}