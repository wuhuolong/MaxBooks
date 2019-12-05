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
    public class xcDBTaskGuideWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBTaskGuide), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTaskGuideInfo", _m_GetTaskGuideInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTaskBarGuideInfo", _m_GetTaskBarGuideInfo);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBTaskGuide), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBTaskGuide), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBTaskGuide));
			
			
			XUtils.EndClassRegister(typeof(xc.DBTaskGuide), L, translator);
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
					
					xc.DBTaskGuide __cl_gen_ret = new xc.DBTaskGuide(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTaskGuide constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskGuideInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBTaskGuide __cl_gen_to_be_invoked = (xc.DBTaskGuide)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    uint taskId = LuaAPI.xlua_touint(L, 2);
                    uint taskState = LuaAPI.xlua_touint(L, 3);
                    uint taskGuideType = LuaAPI.xlua_touint(L, 4);
                    
                        xc.DBTaskGuide.TaskGuideInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskGuideInfo( taskId, taskState, taskGuideType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint taskId = LuaAPI.xlua_touint(L, 2);
                    uint taskState = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBTaskGuide.TaskGuideInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskGuideInfo( taskId, taskState );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTaskGuide.GetTaskGuideInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskBarGuideInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBTaskGuide __cl_gen_to_be_invoked = (xc.DBTaskGuide)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 2);
                    uint taskState = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBTaskGuide.TaskGuideInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskBarGuideInfo( taskId, taskState );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
