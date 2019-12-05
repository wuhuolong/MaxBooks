//************************************
//  Mutex.cs
// mutex
//  Created by leon @INCEPTION .
//  Last modify 15/1/7 create
//************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SGameEngine
{
    public class Mutex
    {
        private HashSet<string> locked_set_ = new HashSet<string>(); //the res current locked

		public IEnumerator try_lock_croutine(string _res)
		{
			do
			{
				yield return new WaitForEndOfFrame();
			}
			while(!try_lock(_res));
		}

		//lock a res
        public bool try_lock(string _res)
        {
			if(locked_set_.Contains(_res))
			{
				return false;
			}
			else
			{
				locked_set_.Add(_res);
				return true;
			}
        }

        //unlock a res
        public void unlock(string _res)
        {
            locked_set_.Remove(_res);
        }

        //decide if locked 
        public bool is_locked(string _res)
        {
            return locked_set_.Contains(_res);
        }
    }
}
