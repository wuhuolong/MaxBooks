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
    public class SGameEngineAssetResourceWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(SGameEngine.AssetResource), L, translator, 0, 3, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "destroy", _m_destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "set_obj", _m_set_obj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "get_obj", _m_get_obj);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "asset_", _g_get_asset_);
            
			
			XUtils.EndObjectRegister(typeof(SGameEngine.AssetResource), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(SGameEngine.AssetResource), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(SGameEngine.AssetResource));
			
			
			XUtils.EndClassRegister(typeof(SGameEngine.AssetResource), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					SGameEngine.AssetResource __cl_gen_ret = new SGameEngine.AssetResource();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.AssetResource constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.AssetResource __cl_gen_to_be_invoked = (SGameEngine.AssetResource)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_set_obj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.AssetResource __cl_gen_to_be_invoked = (SGameEngine.AssetResource)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    SGameEngine.AssetObject _asset_obj = (SGameEngine.AssetObject)translator.GetObject(L, 2, typeof(SGameEngine.AssetObject));
                    
                    __cl_gen_to_be_invoked.set_obj( _asset_obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_obj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.AssetResource __cl_gen_to_be_invoked = (SGameEngine.AssetResource)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        SGameEngine.AssetObject __cl_gen_ret = __cl_gen_to_be_invoked.get_obj(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_asset_(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.AssetResource __cl_gen_to_be_invoked = (SGameEngine.AssetResource)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.asset_);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
