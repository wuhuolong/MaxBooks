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
    public class xcDBHangWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBHang), L, translator, 0, 4, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSuitableHangInfo", _m_GetSuitableHangInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHangIdByInstanceIdAndTagId", _m_GetHangIdByInstanceIdAndTagId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTagIndexByInstanceIdAndTagId", _m_GetTagIndexByInstanceIdAndTagId);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBHang), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBHang), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBHang));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.DBHang), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string name = LuaAPI.lua_tostring(L, 2);
					string path = LuaAPI.lua_tostring(L, 3);
					
					xc.DBHang __cl_gen_ret = new xc.DBHang(name, path);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBHang constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBHang __cl_gen_to_be_invoked = (xc.DBHang)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSuitableHangInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBHang __cl_gen_to_be_invoked = (xc.DBHang)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.HangInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetSuitableHangInfo(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHangIdByInstanceIdAndTagId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBHang __cl_gen_to_be_invoked = (xc.DBHang)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    uint tagId = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetHangIdByInstanceIdAndTagId( instanceId, tagId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTagIndexByInstanceIdAndTagId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBHang __cl_gen_to_be_invoked = (xc.DBHang)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    uint tagId = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetTagIndexByInstanceIdAndTagId( instanceId, tagId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.DBHang.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
