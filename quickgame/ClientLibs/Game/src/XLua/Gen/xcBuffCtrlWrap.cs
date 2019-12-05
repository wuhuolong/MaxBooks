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
    public class xcBuffCtrlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.BuffCtrl), L, translator, 0, 15, 2, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBuff", _m_GetBuff);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBuff", _m_AddBuff);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelBuff", _m_DelBuff);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasActive", _m_HasActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelBattleStatus", _m_DelBattleStatus);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBuff_out", _m_AddBuff_out);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelAllBuff", _m_DelAllBuff);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBuffLayer", _m_SetBuffLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBuffLayer", _m_GetBuffLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddEffectObj", _m_AddEffectObj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyEffectObj", _m_DestroyEffectObj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetAllEffectObj", _m_ResetAllEffectObj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBuffWord", _m_AddBuffWord);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllBuffs", _g_get_AllBuffs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortBuffs", _g_get_SortBuffs);
            
			
			XUtils.EndObjectRegister(typeof(xc.BuffCtrl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.BuffCtrl), L, __CreateInstance, 4, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RegisterAllMessage", _m_RegisterAllMessage_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HandleNotifyAddBuff", _m_HandleNotifyAddBuff_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HandleNotifyDeleteBuff", _m_HandleNotifyDeleteBuff_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.BuffCtrl));
			
			
			XUtils.EndClassRegister(typeof(xc.BuffCtrl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Actor>(L, 2))
				{
					Actor owner = (Actor)translator.GetObject(L, 2, typeof(Actor));
					
					xc.BuffCtrl __cl_gen_ret = new xc.BuffCtrl(owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.BuffCtrl constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBuff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Buff __cl_gen_ret = __cl_gen_to_be_invoked.GetBuff( buff_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.BuffCtrl.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBuff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    float life_time = (float)LuaAPI.lua_tonumber(L, 3);
                    uint layer = LuaAPI.xlua_touint(L, 4);
                    
                        xc.Buff __cl_gen_ret = __cl_gen_to_be_invoked.AddBuff( buff_id, life_time, layer );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    float life_time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        xc.Buff __cl_gen_ret = __cl_gen_to_be_invoked.AddBuff( buff_id, life_time );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.BuffCtrl.AddBuff!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelBuff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DelBuff( buff_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasActive( buff_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelBattleStatus(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string status = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.DelBattleStatus( status );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_HandleNotifyAddBuff_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                    xc.BuffCtrl.HandleNotifyAddBuff( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBuff_out(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    float life_time = (float)LuaAPI.lua_tonumber(L, 3);
                    uint layer = LuaAPI.xlua_touint(L, 4);
                    uint no_tips = LuaAPI.xlua_touint(L, 5);
                    
                    __cl_gen_to_be_invoked.AddBuff_out( buff_id, life_time, layer, no_tips );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleNotifyDeleteBuff_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                    xc.BuffCtrl.HandleNotifyDeleteBuff( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelAllBuff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.DelAllBuff(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBuffLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    uint layer = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetBuffLayer( buff_id, layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBuffLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetBuffLayer( buff_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddEffectObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    DBBuffSev.DBBuffInfo buff_info = (DBBuffSev.DBBuffInfo)translator.GetObject(L, 2, typeof(DBBuffSev.DBBuffInfo));
                    
                    __cl_gen_to_be_invoked.AddEffectObj( buff_info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyEffectObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint buff_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DestroyEffectObj( buff_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetAllEffectObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetAllEffectObj(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBuffWord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    DBBuffSev.DBBuffInfo buff_info = (DBBuffSev.DBBuffInfo)translator.GetObject(L, 2, typeof(DBBuffSev.DBBuffInfo));
                    
                    __cl_gen_to_be_invoked.AddBuffWord( buff_info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllBuffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllBuffs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortBuffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.BuffCtrl __cl_gen_to_be_invoked = (xc.BuffCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SortBuffs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
