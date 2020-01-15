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
    public class xcResNameMappingWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ResNameMapping), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMappingName", _m_GetMappingName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMappingPath", _m_GetMappingPath);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBinFiles", _m_GetBinFiles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPatchFiles", _m_GetPatchFiles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetExVersionName", _m_GetExVersionName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTableFileName", _m_GetTableFileName);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ResNameMapping), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ResNameMapping), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ResNameMapping));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.ResNameMapping), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ResNameMapping __cl_gen_ret = new xc.ResNameMapping();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ResNameMapping constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.Init( filePath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMappingName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetMappingName( fileName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMappingPath(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileFullPath = LuaAPI.lua_tostring(L, 2);
                    string fileFolder = LuaAPI.lua_tostring(L, 3);
                    string fileName = LuaAPI.lua_tostring(L, 4);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetMappingPath( fileFullPath, fileFolder, fileName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBinFiles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = __cl_gen_to_be_invoked.GetBinFiles(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPatchFiles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = __cl_gen_to_be_invoked.GetPatchFiles(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExVersionName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool original = LuaAPI.lua_toboolean(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetExVersionName( original );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetExVersionName(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ResNameMapping.GetExVersionName!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTableFileName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ResNameMapping __cl_gen_to_be_invoked = (xc.ResNameMapping)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool original = LuaAPI.lua_toboolean(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetTableFileName( original );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetTableFileName(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ResNameMapping.GetTableFileName!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.ResNameMapping.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
