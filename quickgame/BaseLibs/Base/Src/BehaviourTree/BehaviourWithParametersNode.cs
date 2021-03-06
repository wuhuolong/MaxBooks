using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    /// <summary>
    /// 支援含有参数Invoke函数的Component
    /// 在一个component节点的格式为：
    /// "parametertype":"type0,type1|type0,type1",
    /// "parametervalue":"value0,value1|value0,value1"
    /// 用"|"分隔多个函数的参数列表，用","分隔多个参数
    /// 对于random类型的参数，使用"~"符号分隔参数范围
    /// </summary>
    public abstract class BehaviourWithParametersNode:BehaviourNode
    {
        //  參數類型列表
        private const string mIntRandomType = "intrandom";
        private const string mFloatRandomType = "floatrandom";
        private const string mIntType = "int";
        private const string mFloatType = "float";
        private const string mBoolType = "bool";
        private const string mStringType = "string";

        private Dictionary<int, object[]> mParameters = new Dictionary<int, object[]>();

        public BehaviourWithParametersNode(IBehaviourEmployee employee)
            : base(employee)
        {

        }

        /// <summary>
        /// 解析参数
        /// </summary>
        /// <param name="options"></param>
        protected void ParseParamters(Hashtable options)
        {
            if (options == null)
            {
                Debug.LogError("BehaviourWithParametersComponent::ParseParamters error,options is null");
                return;
            }

            Dictionary<int, ArrayList> parametersType = new Dictionary<int, ArrayList>();
            Dictionary<int, ArrayList> parametersValue = new Dictionary<int, ArrayList>();

            // 解析參數类型
            string parametersTypeString = options["parametertype"] as string;

            if (!String.IsNullOrEmpty(parametersTypeString))
            {
                string[] functors = parametersTypeString.Split('|');

                int index = 0;
                foreach (var functor in functors)
                {
                    string[] types = functor.Split(',');

                    ArrayList typesArray = new ArrayList();
                    foreach (var stringType in types)
                    {
                        typesArray.Add(stringType);
                    }

                    parametersType.Add(index, typesArray);

                    ++index;
                }
            }

            // 解析参数值
            string parametersValueString = options["parametervalue"] as string;

            if (!String.IsNullOrEmpty(parametersValueString))
            {
                string[] functors = parametersValueString.Split('|');

                int index = 0;
                foreach (var functor in functors)
                {
                    string[] values = functor.Split(',');

                    ArrayList valuesArray = new ArrayList();
                    foreach (var stringValue in values)
                    {
                        valuesArray.Add(stringValue);
                    }

                    parametersValue.Add(index, valuesArray);

                    ++index;
                }
            }

            // 打包参数
            for (int functorIndex = 0; functorIndex < parametersType.Count; functorIndex++)
            {
                object[] parameters = null;

                ArrayList types;
                ArrayList values;

                parametersType.TryGetValue(functorIndex, out types);
                parametersValue.TryGetValue(functorIndex, out values);

                if (types != null && values != null && types.Count > 0 && values.Count > 0)
                {
                    parameters = StringToParametersList(types, values);
                }

                if (parameters == null)
                {
                    parameters = new object[] { };
                }

                mParameters.Add(functorIndex, parameters);
            }
        }
        /// <summary>
        ///  打包最终给函数回凋所用的数据
        /// </summary>
        /// <param name="functorIndex">函数索引</param>
        /// <returns></returns>
        protected object[] PackInvokeParamters(int functorIndex)
        {
            object[] parameters;
            if (mParameters.TryGetValue(functorIndex, out parameters))
            {
                return parameters;
            }

            return new object[] { };
        }
        /// <summary>
        /// 字符串转换成参数列表
        /// </summary>
        /// <param name="types"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static object[] StringToParametersList(ArrayList types, ArrayList values)
        {
            object[] parameters = new object[types.Count];

            for (int i = 0; i < types.Count; i++)
            {
                string type = types[i] as string;
                string value = values[i] as string;

                type.ToLower();

                if (type == mIntRandomType)
                {
                    string[] randomRange = value.Split('~');

                    int begin = 0;
                    int end = 0;

                    if (randomRange.Length < 1)
                    {
                        parameters[i] = begin;
                    }
                    else if (randomRange.Length == 1)
                    {
                        int.TryParse(randomRange[0], out begin);

                        parameters[i] = begin;
                    }
                    else
                    {
                        int.TryParse(randomRange[0], out begin);
                        int.TryParse(randomRange[1], out end);

                        parameters[i] = UnityEngine.Random.Range(begin, end);
                    }
                }
                else if (type == mFloatRandomType)
                {
                    string[] randomRange = value.Split('~');

                    float begin = 0;
                    float end = 0;

                    if (randomRange.Length < 1)
                    {
                        parameters[i] = begin;
                    }
                    else if (randomRange.Length == 1)
                    {
                        float.TryParse(randomRange[0], out begin);

                        parameters[i] = begin;
                    }
                    else
                    {
                        float.TryParse(randomRange[0], out begin);
                        float.TryParse(randomRange[1], out end);

                        parameters[i] = UnityEngine.Random.Range(begin, end);
                    }
                }
                else if (type == mIntType)
                {
                    int result = 0;
                    int.TryParse(value, out result);

                    parameters[i] = result;
                }
                else if (type == mFloatType)
                {
                    float result = 0;
                    float.TryParse(value, out result);

                    parameters[i] = result;
                }
                else if (type == mBoolType)
                {
                    bool result = true;
                    bool.TryParse(value, out result);

                    parameters[i] = result;
                }
                else if (type == mStringType)
                {
                    parameters[i] = value;
                }
            }

            return parameters;
        }
    }
}