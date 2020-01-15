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
    public class xcDBGemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGem), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGemInfo", _m_GetGemInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGemInfosByType", _m_GetGemInfosByType);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBGem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string strName = LuaAPI.lua_tostring(L, 2);
					string strPath = LuaAPI.lua_tostring(L, 3);
					
					xc.DBGem __cl_gen_ret = new xc.DBGem(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGem __cl_gen_to_be_invoked = (xc.DBGem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBGem.GemInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetGemInfo( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemInfosByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGem __cl_gen_to_be_invoked = (xc.DBGem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    byte type = (byte)LuaAPI.lua_tonumber(L, 2);
                    
                        System.Collections.Generic.List<xc.DBGem.GemInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetGemInfosByType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
