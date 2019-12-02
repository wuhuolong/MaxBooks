using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
	public abstract class BehaviourWithParametersNode : BehaviourNode
	{
		private const string mIntRandomType = "intrandom";

		private const string mFloatRandomType = "floatrandom";

		private const string mIntType = "int";

		private const string mFloatType = "float";

		private const string mBoolType = "bool";

		private const string mStringType = "string";

		private Dictionary<int, object[]> mParameters = new Dictionary<int, object[]>();

		public BehaviourWithParametersNode(IBehaviourEmployee employee) : base(employee)
		{
		}

		protected void ParseParamters(Hashtable options)
		{
			bool flag = options == null;
			if (flag)
			{
				Debug.LogError("BehaviourWithParametersComponent::ParseParamters error,options is null");
			}
			else
			{
				Dictionary<int, ArrayList> dictionary = new Dictionary<int, ArrayList>();
				Dictionary<int, ArrayList> dictionary2 = new Dictionary<int, ArrayList>();
				string text = options.get_Item("parametertype") as string;
				bool flag2 = !string.IsNullOrEmpty(text);
				int num2;
				if (flag2)
				{
					string[] array = text.Split(new char[]
					{
						'|'
					});
					int num = 0;
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text2 = array2[i];
						string[] array3 = text2.Split(new char[]
						{
							','
						});
						ArrayList arrayList = new ArrayList();
						string[] array4 = array3;
						for (int j = 0; j < array4.Length; j++)
						{
							string text3 = array4[j];
							arrayList.Add(text3);
						}
						dictionary.Add(num, arrayList);
						num2 = num + 1;
						num = num2;
					}
				}
				string text4 = options.get_Item("parametervalue") as string;
				bool flag3 = !string.IsNullOrEmpty(text4);
				if (flag3)
				{
					string[] array5 = text4.Split(new char[]
					{
						'|'
					});
					int num3 = 0;
					string[] array6 = array5;
					for (int k = 0; k < array6.Length; k++)
					{
						string text5 = array6[k];
						string[] array7 = text5.Split(new char[]
						{
							','
						});
						ArrayList arrayList2 = new ArrayList();
						string[] array8 = array7;
						for (int l = 0; l < array8.Length; l++)
						{
							string text6 = array8[l];
							arrayList2.Add(text6);
						}
						dictionary2.Add(num3, arrayList2);
						num2 = num3 + 1;
						num3 = num2;
					}
				}
				for (int m = 0; m < dictionary.get_Count(); m = num2 + 1)
				{
					object[] array9 = null;
					ArrayList arrayList3;
					dictionary.TryGetValue(m, ref arrayList3);
					ArrayList arrayList4;
					dictionary2.TryGetValue(m, ref arrayList4);
					bool flag4 = arrayList3 != null && arrayList4 != null && arrayList3.get_Count() > 0 && arrayList4.get_Count() > 0;
					if (flag4)
					{
						array9 = BehaviourWithParametersNode.StringToParametersList(arrayList3, arrayList4);
					}
					bool flag5 = array9 == null;
					if (flag5)
					{
						array9 = new object[0];
					}
					this.mParameters.Add(m, array9);
					num2 = m;
				}
			}
		}

		protected object[] PackInvokeParamters(int functorIndex)
		{
			object[] array;
			bool flag = this.mParameters.TryGetValue(functorIndex, ref array);
			object[] result;
			if (flag)
			{
				result = array;
			}
			else
			{
				result = new object[0];
			}
			return result;
		}

		private static object[] StringToParametersList(ArrayList types, ArrayList values)
		{
			object[] array = new object[types.get_Count()];
			int num7;
			for (int i = 0; i < types.get_Count(); i = num7 + 1)
			{
				string text = types.get_Item(i) as string;
				string text2 = values.get_Item(i) as string;
				text.ToLower();
				bool flag = text == "intrandom";
				if (flag)
				{
					string[] array2 = text2.Split(new char[]
					{
						'~'
					});
					int num = 0;
					int num2 = 0;
					bool flag2 = array2.Length < 1;
					if (flag2)
					{
						array[i] = num;
					}
					else
					{
						bool flag3 = array2.Length == 1;
						if (flag3)
						{
							int.TryParse(array2[0], ref num);
							array[i] = num;
						}
						else
						{
							int.TryParse(array2[0], ref num);
							int.TryParse(array2[1], ref num2);
							array[i] = Random.Range(num, num2);
						}
					}
				}
				else
				{
					bool flag4 = text == "floatrandom";
					if (flag4)
					{
						string[] array3 = text2.Split(new char[]
						{
							'~'
						});
						float num3 = 0f;
						float num4 = 0f;
						bool flag5 = array3.Length < 1;
						if (flag5)
						{
							array[i] = num3;
						}
						else
						{
							bool flag6 = array3.Length == 1;
							if (flag6)
							{
								float.TryParse(array3[0], ref num3);
								array[i] = num3;
							}
							else
							{
								float.TryParse(array3[0], ref num3);
								float.TryParse(array3[1], ref num4);
								array[i] = Random.Range(num3, num4);
							}
						}
					}
					else
					{
						bool flag7 = text == "int";
						if (flag7)
						{
							int num5 = 0;
							int.TryParse(text2, ref num5);
							array[i] = num5;
						}
						else
						{
							bool flag8 = text == "float";
							if (flag8)
							{
								float num6 = 0f;
								float.TryParse(text2, ref num6);
								array[i] = num6;
							}
							else
							{
								bool flag9 = text == "bool";
								if (flag9)
								{
									bool flag10 = true;
									bool.TryParse(text2, ref flag10);
									array[i] = flag10;
								}
								else
								{
									bool flag11 = text == "string";
									if (flag11)
									{
										array[i] = text2;
									}
								}
							}
						}
					}
				}
				num7 = i;
			}
			return array;
		}
	}
}
