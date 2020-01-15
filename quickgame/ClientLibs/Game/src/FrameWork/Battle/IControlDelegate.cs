using UnityEngine;
using System.Collections;

namespace xc
{
	public interface IControlDelegate
	{
		bool Stop();
		bool WalkTo(Vector3 dst);
		bool WalkAlong(Vector3 dir);
		bool Attack(uint skillID);
		void Beattacked(Damage dam);
		
	}
}


