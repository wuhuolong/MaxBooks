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
    public class xcBuffWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Buff), L, translator, 0, 6, 8, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetTime", _m_ResetTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Delete", _m_Delete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetOverlayNum", _m_SetOverlayNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOverlayNum", _m_GetOverlayNum);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Target_P", _g_get_Target_P);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Progress", _g_get_Progress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RemainTime", _g_get_RemainTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OwnBuffInfo", _g_get_OwnBuffInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasActive", _g_get_HasActive);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedDel", _g_get_NeedDel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_BuffId", _g_get_m_BuffId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShiftExcept", _g_get_ShiftExcept);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_BuffId", _s_set_m_BuffId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShiftExcept", _s_set_ShiftExcept);
            
			XUtils.EndObjectRegister(typeof(xc.Buff), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Buff), L, __CreateInstance, 3, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBattleState", _m_GetBattleState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Construct", _m_Construct_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Buff));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BattleStateCount", _g_get_BattleStateCount);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "BattleStateCount", _s_set_BattleStateCount);
            
			XUtils.EndClassRegister(typeof(xc.Buff), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.Buff does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBattleState_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string type_str = LuaAPI.lua_tostring(L, 1);
                    
                        xc.BattleStatusType __cl_gen_ret = xc.Buff.GetBattleState( type_str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.BuffCtrl buff_ctrl = (xc.BuffCtrl)translator.GetObject(L, 1, typeof(xc.BuffCtrl));
                    xc.Buff.BuffInfo kInfo = (xc.Buff.BuffInfo)translator.GetObject(L, 2, typeof(xc.Buff.BuffInfo));
                    float lifeTime = (float)LuaAPI.lua_tonumber(L, 3);
                    uint layer = LuaAPI.xlua_touint(L, 4);
                    bool shiftExcept = LuaAPI.lua_toboolean(L, 5);
                    
                        xc.Buff __cl_gen_ret = xc.Buff.Construct( buff_ctrl, kInfo, lifeTime, layer, shiftExcept );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Buff.BuffInfo buff_info = (xc.Buff.BuffInfo)translator.GetObject(L, 2, typeof(xc.Buff.BuffInfo));
                    float lifeTime = (float)LuaAPI.lua_tonumber(L, 3);
                    uint layer = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.Reset( buff_info, lifeTime, layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float lifeTime = (float)LuaAPI.lua_tonumber(L, 2);
                    uint layer = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ResetTime( lifeTime, layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Delete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOverlayNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint num = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetOverlayNum( num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOverlayNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetOverlayNum(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Target_P(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Target_P);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Progress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Progress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RemainTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.RemainTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OwnBuffInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OwnBuffInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasActive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasActive);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedDel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedDel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BattleStateCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.Buff.BattleStateCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_BuffId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_BuffId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShiftExcept(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShiftExcept);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BattleStateCount(RealStatePtr L)
        {
            
            try {
			    xc.Buff.BattleStateCount = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_BuffId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_BuffId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShiftExcept(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff __cl_gen_to_be_invoked = (xc.Buff)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShiftExcept = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
