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
    public class NpcScenePositionWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(NpcScenePosition), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SceneId", _g_get_SceneId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NpcId", _g_get_NpcId);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SceneId", _s_set_SceneId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NpcId", _s_set_NpcId);
            
			XUtils.EndObjectRegister(typeof(NpcScenePosition), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(NpcScenePosition), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Make", _m_Make_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(NpcScenePosition));
			
			
			XUtils.EndClassRegister(typeof(NpcScenePosition), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			translator.Push(L, default(NpcScenePosition));
			return 1;
			
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Make_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        NpcScenePosition __cl_gen_ret = NpcScenePosition.Make( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<System.Collections.Generic.List<string>>(L, 1)) 
                {
                    System.Collections.Generic.List<string> strings = (System.Collections.Generic.List<string>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<string>));
                    
                        NpcScenePosition __cl_gen_ret = NpcScenePosition.Make( strings );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to NpcScenePosition.Make!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SceneId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                NpcScenePosition __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SceneId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                NpcScenePosition __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SceneId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                NpcScenePosition __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked.SceneId = LuaAPI.xlua_touint(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                NpcScenePosition __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked.NpcId = LuaAPI.xlua_touint(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
