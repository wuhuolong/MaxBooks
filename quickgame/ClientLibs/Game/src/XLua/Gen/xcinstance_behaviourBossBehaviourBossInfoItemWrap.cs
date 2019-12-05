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
    public class xcinstance_behaviourBossBehaviourBossInfoItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem), L, translator, 0, 2, 7, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateExchangeModel", _m_UpdateExchangeModel);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasCreatedInterObject", _g_get_HasCreatedInterObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_pkgBossInfo", _g_get_m_pkgBossInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_need_update_exchange_model", _g_get_m_need_update_exchange_model);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_uid", _g_get_m_uid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_monster_name", _g_get_m_monster_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_model_Quaternion", _g_get_m_model_Quaternion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_pos", _g_get_m_pos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_pkgBossInfo", _s_set_m_pkgBossInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_need_update_exchange_model", _s_set_m_need_update_exchange_model);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_uid", _s_set_m_uid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_monster_name", _s_set_m_monster_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_model_Quaternion", _s_set_m_model_Quaternion);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_pos", _s_set_m_pos);
            
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour.BossInfoItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_ret = new xc.instance_behaviour.BossBehaviour.BossInfoItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.BossInfoItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateExchangeModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateExchangeModel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasCreatedInterObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasCreatedInterObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_pkgBossInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_pkgBossInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_need_update_exchange_model(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_need_update_exchange_model);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_uid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_uid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_monster_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.m_monster_name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_model_Quaternion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineQuaternion(L, __cl_gen_to_be_invoked.m_model_Quaternion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.m_pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_pkgBossInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_pkgBossInfo = (Net.PkgBossInfo)translator.GetObject(L, 2, typeof(Net.PkgBossInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_need_update_exchange_model(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_need_update_exchange_model = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_uid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_uid = (xc.InterObjectUnitID)translator.GetObject(L, 2, typeof(xc.InterObjectUnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_monster_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_monster_name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_model_Quaternion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Quaternion __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_model_Quaternion = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.BossInfoItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.BossInfoItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_pos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
