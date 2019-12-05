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
    public class xcClassConstructHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ClassConstructHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ClassConstructHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ClassConstructHelper), L, __CreateInstance, 4, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ConstructRect", _m_ConstructRect_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ConstructCommonInstanceState", _m_ConstructCommonInstanceState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ConstructDateTime", _m_ConstructDateTime_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClassConstructHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.ClassConstructHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ClassConstructHelper __cl_gen_ret = new xc.ClassConstructHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClassConstructHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConstructRect_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    float left = (float)LuaAPI.lua_tonumber(L, 1);
                    float top = (float)LuaAPI.lua_tonumber(L, 2);
                    float width = (float)LuaAPI.lua_tonumber(L, 3);
                    float height = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        UnityEngine.Rect __cl_gen_ret = xc.ClassConstructHelper.ConstructRect( left, top, width, height );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConstructCommonInstanceState_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string lua_script = LuaAPI.lua_tostring(L, 1);
                    uint id = LuaAPI.xlua_touint(L, 2);
                    xc.Machine machine = (xc.Machine)translator.GetObject(L, 3, typeof(xc.Machine));
                    
                        xc.Machine.State __cl_gen_ret = xc.ClassConstructHelper.ConstructCommonInstanceState( lua_script, id, machine );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConstructDateTime_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int year = LuaAPI.xlua_tointeger(L, 1);
                    int month = LuaAPI.xlua_tointeger(L, 2);
                    int day = LuaAPI.xlua_tointeger(L, 3);
                    int hour = LuaAPI.xlua_tointeger(L, 4);
                    int minute = LuaAPI.xlua_tointeger(L, 5);
                    int second = LuaAPI.xlua_tointeger(L, 6);
                    
                        System.DateTime __cl_gen_ret = xc.ClassConstructHelper.ConstructDateTime( year, month, day, hour, minute, second );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
