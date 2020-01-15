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
    public class xcActorAttributeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ActorAttribute), L, translator, 0, 6, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAttr", _m_GetAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Add", _m_Add);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Remove", _m_Remove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBattlePower", _m_GetBattlePower);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            
			
			XUtils.EndObjectRegister(typeof(xc.ActorAttribute), L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ActorAttribute), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseByPkgKvMins", _m_ParseByPkgKvMins_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorAttribute));
			
			
			XUtils.EndClassRegister(typeof(xc.ActorAttribute), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ActorAttribute __cl_gen_ret = new xc.ActorAttribute();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorAttribute constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				
				if (translator.Assignable<xc.ActorAttribute>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
					uint index = LuaAPI.xlua_touint(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					translator.Push(L, __cl_gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<xc.ActorAttribute>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<xc.IActorAttribute>(L, 3))
				{
					
					xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
					uint key = LuaAPI.xlua_touint(L, 2);
					__cl_gen_to_be_invoked[key] = (xc.IActorAttribute)translator.GetObject(L, 3, typeof(xc.IActorAttribute));
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint key = LuaAPI.xlua_touint(L, 2);
                    
                        xc.IActorAttribute __cl_gen_ret = __cl_gen_to_be_invoked.GetAttr( key );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    long value = LuaAPI.lua_toint64(L, 3);
                    bool bMerge = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.Add( id, value, bMerge );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))) 
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    long value = LuaAPI.lua_toint64(L, 3);
                    
                    __cl_gen_to_be_invoked.Add( id, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorAttribute.Add!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Remove( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBattlePower(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetBattlePower(  );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.ActorAttribute __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseByPkgKvMins_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgKvMin> pkgKvMins = (System.Collections.Generic.List<Net.PkgKvMin>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Net.PkgKvMin>));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.ActorAttribute.ParseByPkgKvMins( pkgKvMins );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorAttribute __cl_gen_to_be_invoked = (xc.ActorAttribute)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
