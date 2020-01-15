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
    public class ChatVoicePressCtrlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ChatVoicePressCtrl), L, translator, 0, 0, 0, 1);
			
			
			
			
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PressTime", _s_set_PressTime);
            
			XUtils.EndObjectRegister(typeof(ChatVoicePressCtrl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ChatVoicePressCtrl), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ChatVoicePressCtrl));
			
			
			XUtils.EndClassRegister(typeof(ChatVoicePressCtrl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ChatVoicePressCtrl __cl_gen_ret = new ChatVoicePressCtrl();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ChatVoicePressCtrl constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PressTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ChatVoicePressCtrl __cl_gen_to_be_invoked = (ChatVoicePressCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PressTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
