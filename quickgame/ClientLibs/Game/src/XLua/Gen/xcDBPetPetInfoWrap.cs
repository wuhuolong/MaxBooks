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
    public class xcDBPetPetInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBPet.PetInfo), L, translator, 0, 2, 35, 35);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetQualityDescStr", _m_GetQualityDescStr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVocationPlayerSkills", _m_GetVocationPlayerSkills);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnlockType", _g_get_UnlockType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnlockPlayerLevel", _g_get_UnlockPlayerLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnLockGoodsConditionArray", _g_get_UnLockGoodsConditionArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnLockPrePetConditionData", _g_get_UnLockPrePetConditionData);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PreIdInEvolution", _g_get_PreIdInEvolution);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasCheckEvolution", _g_get_HasCheckEvolution);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FirstPetIdInEvolution", _g_get_FirstPetIdInEvolution);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Unlock_desc", _g_get_Unlock_desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Rank", _g_get_Rank);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Actor_id", _g_get_Actor_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Quality", _g_get_Quality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxStep", _g_get_MaxStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxQual", _g_get_MaxQual);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllSkills", _g_get_AllSkills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Skills", _g_get_Skills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PassivitySkills", _g_get_PassivitySkills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffset", _g_get_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffsetInfo", _g_get_ModelCameraOffsetInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraRotate", _g_get_ModelCameraRotate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelDefaultAngle", _g_get_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffset2", _g_get_ModelCameraOffset2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffset3", _g_get_ModelCameraOffset3);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalPos", _g_get_ModelLocalPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalScale", _g_get_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalAngles", _g_get_ModelLocalAngles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalPos2", _g_get_ModelLocalPos2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalScale2", _g_get_ModelLocalScale2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelShowModelOffset", _g_get_ModelShowModelOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelShowCameraOffset", _g_get_ModelShowCameraOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelShowCameraRotation", _g_get_ModelShowCameraRotation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelShowScale", _g_get_ModelShowScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayerSkills", _g_get_PlayerSkills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Head_icon", _g_get_Head_icon);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Desc", _s_set_Desc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnlockType", _s_set_UnlockType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnlockPlayerLevel", _s_set_UnlockPlayerLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnLockGoodsConditionArray", _s_set_UnLockGoodsConditionArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnLockPrePetConditionData", _s_set_UnLockPrePetConditionData);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PreIdInEvolution", _s_set_PreIdInEvolution);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HasCheckEvolution", _s_set_HasCheckEvolution);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FirstPetIdInEvolution", _s_set_FirstPetIdInEvolution);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Unlock_desc", _s_set_Unlock_desc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Rank", _s_set_Rank);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Actor_id", _s_set_Actor_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Quality", _s_set_Quality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxStep", _s_set_MaxStep);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxQual", _s_set_MaxQual);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AllSkills", _s_set_AllSkills);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Skills", _s_set_Skills);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PassivitySkills", _s_set_PassivitySkills);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffset", _s_set_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffsetInfo", _s_set_ModelCameraOffsetInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraRotate", _s_set_ModelCameraRotate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelDefaultAngle", _s_set_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffset2", _s_set_ModelCameraOffset2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffset3", _s_set_ModelCameraOffset3);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalPos", _s_set_ModelLocalPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalScale", _s_set_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalAngles", _s_set_ModelLocalAngles);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalPos2", _s_set_ModelLocalPos2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalScale2", _s_set_ModelLocalScale2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelShowModelOffset", _s_set_ModelShowModelOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelShowCameraOffset", _s_set_ModelShowCameraOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelShowCameraRotation", _s_set_ModelShowCameraRotation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelShowScale", _s_set_ModelShowScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PlayerSkills", _s_set_PlayerSkills);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Head_icon", _s_set_Head_icon);
            
			XUtils.EndObjectRegister(typeof(xc.DBPet.PetInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBPet.PetInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBPet.PetInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBPet.PetInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBPet.PetInfo __cl_gen_ret = new xc.DBPet.PetInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBPet.PetInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQualityDescStr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetQualityDescStr(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVocationPlayerSkills(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.DBPet.PetSkillItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetVocationPlayerSkills( vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnlockType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushxcDBPetPetUnLockType(L, __cl_gen_to_be_invoked.UnlockType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnlockPlayerLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.UnlockPlayerLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnLockGoodsConditionArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnLockGoodsConditionArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnLockPrePetConditionData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnLockPrePetConditionData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PreIdInEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PreIdInEvolution);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasCheckEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasCheckEvolution);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FirstPetIdInEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FirstPetIdInEvolution);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Unlock_desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Unlock_desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Rank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Rank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Actor_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Actor_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Quality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxQual(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxQual);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllSkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Skills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Skills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PassivitySkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PassivitySkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffsetInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffsetInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraRotate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelDefaultAngle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffset2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffset2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffset3(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffset3);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalAngles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalPos2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalPos2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalScale2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalScale2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelShowModelOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelShowModelOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelShowCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelShowCameraOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelShowCameraRotation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelShowCameraRotation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelShowScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelShowScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayerSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PlayerSkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Head_icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Head_icon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Desc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnlockType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                xc.DBPet.PetUnLockType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.UnlockType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnlockPlayerLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnlockPlayerLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnLockGoodsConditionArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnLockGoodsConditionArray = (System.Collections.Generic.List<xc.DBPet.UnLockGoodsCondition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.UnLockGoodsCondition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnLockPrePetConditionData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnLockPrePetConditionData = (xc.DBPet.UnLockPrePetCondition)translator.GetObject(L, 2, typeof(xc.DBPet.UnLockPrePetCondition));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreIdInEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PreIdInEvolution = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HasCheckEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HasCheckEvolution = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FirstPetIdInEvolution(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FirstPetIdInEvolution = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Unlock_desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Unlock_desc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Rank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Rank = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Actor_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Actor_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Quality = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxStep = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxQual(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxQual = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AllSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AllSkills = (System.Collections.Generic.List<xc.DBPet.PetSkillItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.PetSkillItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Skills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Skills = (System.Collections.Generic.List<xc.DBPet.PetSkillItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.PetSkillItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PassivitySkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PassivitySkills = (System.Collections.Generic.List<xc.DBPet.PetSkillItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.PetSkillItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffsetInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffsetInfo = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraRotate = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelDefaultAngle = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffset2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffset2 = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffset3(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffset3 = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalAngles = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalPos2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalPos2 = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalScale2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalScale2 = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelShowModelOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelShowModelOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelShowCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelShowCameraOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelShowCameraRotation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelShowCameraRotation = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelShowScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelShowScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PlayerSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PlayerSkills = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.DBPet.PetSkillItem>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.DBPet.PetSkillItem>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Head_icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPet.PetInfo __cl_gen_to_be_invoked = (xc.DBPet.PetInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Head_icon = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
