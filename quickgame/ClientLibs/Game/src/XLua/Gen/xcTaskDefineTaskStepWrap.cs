#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcTaskDefineTaskStepWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TaskDefine.TaskStep), L, translator, 0, 0, 32, 32);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Goal", _g_get_Goal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExpectResult", _g_get_ExpectResult);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DialogId", _g_get_DialogId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceId", _g_get_InstanceId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceId2", _g_get_InstanceId2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NpcId", _g_get_NpcId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MonsterId", _g_get_MonsterId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MonsterLevel", _g_get_MonsterLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GoodsId", _g_get_GoodsId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipColor", _g_get_EquipColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipLvStep", _g_get_EquipLvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SecretAreaId", _g_get_SecretAreaId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TrigramId", _g_get_TrigramId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipStrenghtLv", _g_get_EquipStrenghtLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GemType", _g_get_GemType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GemLv", _g_get_GemLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PetLv", _g_get_PetLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GrowType", _g_get_GrowType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GrowLv", _g_get_GrowLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StigmaId", _g_get_StigmaId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StigmaLv", _g_get_StigmaLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SysId", _g_get_SysId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MinWorldBossSpecialMonId", _g_get_MinWorldBossSpecialMonId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxWorldBossSpecialMonId", _g_get_MaxWorldBossSpecialMonId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceLv", _g_get_InstanceLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WarTag", _g_get_WarTag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LightEquipLv", _g_get_LightEquipLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Description", _g_get_Description);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerParamStrings", _g_get_ServerParamStrings);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ClientParamStrings", _g_get_ClientParamStrings);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NavigationInstanceId", _g_get_NavigationInstanceId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NavigationTagId", _g_get_NavigationTagId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Goal", _s_set_Goal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExpectResult", _s_set_ExpectResult);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DialogId", _s_set_DialogId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceId", _s_set_InstanceId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceId2", _s_set_InstanceId2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NpcId", _s_set_NpcId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MonsterId", _s_set_MonsterId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MonsterLevel", _s_set_MonsterLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GoodsId", _s_set_GoodsId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipColor", _s_set_EquipColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipLvStep", _s_set_EquipLvStep);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SecretAreaId", _s_set_SecretAreaId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TrigramId", _s_set_TrigramId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipStrenghtLv", _s_set_EquipStrenghtLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GemType", _s_set_GemType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GemLv", _s_set_GemLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PetLv", _s_set_PetLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GrowType", _s_set_GrowType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GrowLv", _s_set_GrowLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StigmaId", _s_set_StigmaId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StigmaLv", _s_set_StigmaLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SysId", _s_set_SysId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MinWorldBossSpecialMonId", _s_set_MinWorldBossSpecialMonId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxWorldBossSpecialMonId", _s_set_MaxWorldBossSpecialMonId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceLv", _s_set_InstanceLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WarTag", _s_set_WarTag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LightEquipLv", _s_set_LightEquipLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Description", _s_set_Description);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerParamStrings", _s_set_ServerParamStrings);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ClientParamStrings", _s_set_ClientParamStrings);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NavigationInstanceId", _s_set_NavigationInstanceId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NavigationTagId", _s_set_NavigationTagId);
            
			XUtils.EndObjectRegister(typeof(xc.TaskDefine.TaskStep), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TaskDefine.TaskStep), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateStepsByRawString", _m_CreateStepsByRawString_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskDefine.TaskStep));
			
			
			XUtils.EndClassRegister(typeof(xc.TaskDefine.TaskStep), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TaskDefine.TaskStep __cl_gen_ret = new xc.TaskDefine.TaskStep();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine.TaskStep constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateStepsByRawString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string serverRawString = LuaAPI.lua_tostring(L, 1);
                    string clientRawString = LuaAPI.lua_tostring(L, 2);
                    string navigationPointsRawsString = LuaAPI.lua_tostring(L, 3);
                    
                        System.Collections.Generic.List<xc.TaskDefine.TaskStep> __cl_gen_ret = xc.TaskDefine.TaskStep.CreateStepsByRawString( serverRawString, clientRawString, navigationPointsRawsString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Goal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Goal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExpectResult(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ExpectResult);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DialogId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceId2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceId2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MonsterId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MonsterId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MonsterLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MonsterLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GoodsId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipLvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipLvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SecretAreaId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SecretAreaId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TrigramId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TrigramId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipStrenghtLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipStrenghtLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GemType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GemType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GemLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GemLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PetLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PetLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GrowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GrowType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GrowLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GrowLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StigmaId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StigmaId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StigmaLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StigmaLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SysId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinWorldBossSpecialMonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MinWorldBossSpecialMonId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxWorldBossSpecialMonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxWorldBossSpecialMonId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.InstanceLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WarTag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.WarTag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LightEquipLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.LightEquipLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Description);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerParamStrings(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ServerParamStrings);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ClientParamStrings(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ClientParamStrings);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NavigationInstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NavigationInstanceId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NavigationTagId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NavigationTagId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Goal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Goal = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExpectResult(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExpectResult = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DialogId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceId2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceId2 = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NpcId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MonsterId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MonsterId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MonsterLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MonsterLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GoodsId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipColor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipLvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipLvStep = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SecretAreaId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SecretAreaId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TrigramId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TrigramId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipStrenghtLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipStrenghtLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GemType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GemType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GemLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GemLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PetLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PetLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GrowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GrowType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GrowLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GrowLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StigmaId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StigmaId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StigmaLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StigmaLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SysId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinWorldBossSpecialMonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MinWorldBossSpecialMonId = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxWorldBossSpecialMonId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxWorldBossSpecialMonId = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceLv = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WarTag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WarTag = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LightEquipLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LightEquipLv = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Description = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerParamStrings(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerParamStrings = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ClientParamStrings(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ClientParamStrings = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NavigationInstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NavigationInstanceId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NavigationTagId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine.TaskStep __cl_gen_to_be_invoked = (xc.TaskDefine.TaskStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NavigationTagId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
