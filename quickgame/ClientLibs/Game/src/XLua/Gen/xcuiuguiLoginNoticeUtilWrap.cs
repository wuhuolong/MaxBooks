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
    public class xcuiuguiLoginNoticeUtilWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.LoginNoticeUtil), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.LoginNoticeUtil), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.LoginNoticeUtil), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowNormalNotice", _m_ShowNormalNotice_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckData", _m_CheckData_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.LoginNoticeUtil));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.LoginNoticeUtil), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.ui.ugui.LoginNoticeUtil does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowNormalNotice_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.ui.ugui.LoginNoticeUtil.ShowNormalNotice(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckData_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string reply = LuaAPI.lua_tostring(L, 1);
                    xc.ui.ugui.LoginNoticeData data;
                    
                        bool __cl_gen_ret = xc.ui.ugui.LoginNoticeUtil.CheckData( reply, out data );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, data);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
