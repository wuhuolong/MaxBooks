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
    public class xcDBEngraveWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBEngrave), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEngraveInfoByGid", _m_GetEngraveInfoByGid);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEngraveInfosByType", _m_GetEngraveInfosByType);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBEngrave), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBEngrave), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBEngrave));
			
			
			XUtils.EndClassRegister(typeof(xc.DBEngrave), L, translator);
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
					
					xc.DBEngrave __cl_gen_ret = new xc.DBEngrave(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBEngrave constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveInfoByGid(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBEngrave __cl_gen_to_be_invoked = (xc.DBEngrave)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBEngrave.EngraveInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetEngraveInfoByGid( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveInfosByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBEngrave __cl_gen_to_be_invoked = (xc.DBEngrave)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.DBEngrave.EngraveInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetEngraveInfosByType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
