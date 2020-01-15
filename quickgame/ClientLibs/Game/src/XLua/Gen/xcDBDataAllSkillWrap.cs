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
    public class xcDBDataAllSkillWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBDataAllSkill), L, translator, 0, 6, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllSkillInfo", _m_GetAllSkillInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneAllSkillInfo", _m_GetOneAllSkillInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSubSkillIdByAllSkillId", _m_GetSubSkillIdByAllSkillId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneAllSkillInfo_byActiveSkillId", _m_GetOneAllSkillInfo_byActiveSkillId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllActiveSkillInfoBySetSlotType", _m_GetAllActiveSkillInfoBySetSlotType);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBDataAllSkill), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBDataAllSkill), L, __CreateInstance, 3, 0, 0);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CommonVocationType", xc.DBDataAllSkill.CommonVocationType);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PetVocationType", xc.DBDataAllSkill.PetVocationType);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDataAllSkill));
			
			
			XUtils.EndClassRegister(typeof(xc.DBDataAllSkill), L, translator);
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
					
					xc.DBDataAllSkill __cl_gen_ret = new xc.DBDataAllSkill(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBDataAllSkill constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllSkillInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBDataAllSkill.SKILL_TYPE skill_type;translator.Get(L, 2, out skill_type);
                    uint vocation = LuaAPI.xlua_touint(L, 3);
                    
                        System.Collections.Generic.List<xc.DBDataAllSkill.AllSkillInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetAllSkillInfo( skill_type, vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetOneAllSkillInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBDataAllSkill.AllSkillInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetOneAllSkillInfo( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSubSkillIdByAllSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint all_skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetSubSkillIdByAllSkillId( all_skill_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneAllSkillInfo_byActiveSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint active_skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBDataAllSkill.AllSkillInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetOneAllSkillInfo_byActiveSkillId( active_skill_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllActiveSkillInfoBySetSlotType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill __cl_gen_to_be_invoked = (xc.DBDataAllSkill)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    xc.DBDataAllSkill.SET_SLOT_TYPE set_slot_type;translator.Get(L, 3, out set_slot_type);
                    
                        System.Collections.Generic.List<xc.DBDataAllSkill.AllSkillInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetAllActiveSkillInfoBySetSlotType( vocation, set_slot_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
