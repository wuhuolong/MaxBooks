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
    public class xcDBGuildDutyWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildDuty), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneItem", _m_GetOneItem);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBGuildDuty), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildDuty), L, __CreateInstance, 8, 0, 0);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_EnterCheck", xc.DBGuildDuty.GuildDutyLimit_EnterCheck);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_DutyAppoint", xc.DBGuildDuty.GuildDutyLimit_DutyAppoint);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_AlterNotice", xc.DBGuildDuty.GuildDutyLimit_AlterNotice);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_CleanWare", xc.DBGuildDuty.GuildDutyLimit_CleanWare);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_MemberDismiss", xc.DBGuildDuty.GuildDutyLimit_MemberDismiss);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_Boss", xc.DBGuildDuty.GuildDutyLimit_Boss);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GuildDutyLimit_ApplySetting", xc.DBGuildDuty.GuildDutyLimit_ApplySetting);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildDuty));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildDuty), L, translator);
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
					
					xc.DBGuildDuty __cl_gen_ret = new xc.DBGuildDuty(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildDuty constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildDuty __cl_gen_to_be_invoked = (xc.DBGuildDuty)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetOneItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildDuty __cl_gen_to_be_invoked = (xc.DBGuildDuty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBGuildDuty.DBGuildDutyItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneItem( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
