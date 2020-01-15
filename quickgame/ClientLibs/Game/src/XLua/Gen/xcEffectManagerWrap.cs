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
    public class xcEffectManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.EffectManager), L, translator, 0, 9, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IncreaseEffectNum", _m_IncreaseEffectNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DecreaseEffectNum", _m_DecreaseEffectNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExceedEffectNum", _m_ExceedEffectNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSkillInstance", _m_AddSkillInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveSkillInstance", _m_RemoveSkillInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAttackInstance", _m_GetAttackInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEffectEmitter", _m_GetEffectEmitter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddAnimationEffect", _m_AddAnimationEffect);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxPlayerEffectCount", _g_get_MaxPlayerEffectCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_CurEffectNum", _g_get_m_CurEffectNum);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxPlayerEffectCount", _s_set_MaxPlayerEffectCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_CurEffectNum", _s_set_m_CurEffectNum);
            
			XUtils.EndObjectRegister(typeof(xc.EffectManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.EffectManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EffectManager));
			
			
			XUtils.EndClassRegister(typeof(xc.EffectManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.EffectManager __cl_gen_ret = new xc.EffectManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.EffectManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IncreaseEffectNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.IncreaseEffectNum(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecreaseEffectNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DecreaseEffectNum(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExceedEffectNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ExceedEffectNum(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
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
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_AddSkillInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong uiID = LuaAPI.lua_touint64(L, 2);
                    xc.SkillAttackInstance kSkillEffect = (xc.SkillAttackInstance)translator.GetObject(L, 3, typeof(xc.SkillAttackInstance));
                    
                    __cl_gen_to_be_invoked.AddSkillInstance( uiID, kSkillEffect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSkillInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong uiID = LuaAPI.lua_touint64(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.RemoveSkillInstance( uiID );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttackInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong uiID = LuaAPI.lua_touint64(L, 2);
                    
                        xc.SkillAttackInstance __cl_gen_ret = __cl_gen_to_be_invoked.GetAttackInstance( uiID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEffectEmitter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string effectPrefab = LuaAPI.lua_tostring(L, 2);
                    int maxCount = LuaAPI.xlua_tointeger(L, 3);
                    
                        xc.EffectEmitter __cl_gen_ret = __cl_gen_to_be_invoked.GetEffectEmitter( effectPrefab, maxCount );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string effectPrefab = LuaAPI.lua_tostring(L, 2);
                    
                        xc.EffectEmitter __cl_gen_ret = __cl_gen_to_be_invoked.GetEffectEmitter( effectPrefab );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.EffectManager.GetEffectEmitter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAnimationEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.AnimationEffect kEffect = (xc.AnimationEffect)translator.GetObject(L, 2, typeof(xc.AnimationEffect));
                    
                    __cl_gen_to_be_invoked.AddAnimationEffect( kEffect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerEffectCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxPlayerEffectCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_CurEffectNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.m_CurEffectNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerEffectCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxPlayerEffectCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_CurEffectNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EffectManager __cl_gen_to_be_invoked = (xc.EffectManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_CurEffectNum = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
