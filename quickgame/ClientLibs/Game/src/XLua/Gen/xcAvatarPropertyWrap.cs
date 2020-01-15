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
    public class xcAvatarPropertyWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.AvatarProperty), L, translator, 0, 7, 19, 19);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEquipModleIds", _m_GetEquipModleIds);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFashionModleIds", _m_GetFashionModleIds);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEquipPart", _m_SetEquipPart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetFashionPart", _m_SetFashionPart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSuitEffectId", _m_AddSuitEffectId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveSuitEffectId", _m_RemoveSuitEffectId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BodyId", _g_get_BodyId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WeaponId", _g_get_WeaponId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipBodyId", _g_get_EquipBodyId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipWeaponId", _g_get_EquipWeaponId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionBodyId", _g_get_FashionBodyId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionWeaponId", _g_get_FashionWeaponId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionWingId", _g_get_FashionWingId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitEffectIds", _g_get_SuitEffectIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WingResPath", _g_get_WingResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ElfinId", _g_get_ElfinId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ElfinResPath", _g_get_ElfinResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionMagicalPetId", _g_get_FashionMagicalPetId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MagicalPetResPath", _g_get_MagicalPetResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionFootprintId", _g_get_FashionFootprintId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionPhotoFrameId", _g_get_FashionPhotoFrameId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FashionBubbleId", _g_get_FashionBubbleId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LightWeaponId", _g_get_LightWeaponId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BackAttachmentID", _g_get_BackAttachmentID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Vocation", _g_get_Vocation);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BodyId", _s_set_BodyId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WeaponId", _s_set_WeaponId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipBodyId", _s_set_EquipBodyId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipWeaponId", _s_set_EquipWeaponId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionBodyId", _s_set_FashionBodyId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionWeaponId", _s_set_FashionWeaponId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionWingId", _s_set_FashionWingId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SuitEffectIds", _s_set_SuitEffectIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WingResPath", _s_set_WingResPath);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ElfinId", _s_set_ElfinId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ElfinResPath", _s_set_ElfinResPath);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionMagicalPetId", _s_set_FashionMagicalPetId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MagicalPetResPath", _s_set_MagicalPetResPath);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionFootprintId", _s_set_FashionFootprintId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionPhotoFrameId", _s_set_FashionPhotoFrameId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FashionBubbleId", _s_set_FashionBubbleId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LightWeaponId", _s_set_LightWeaponId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BackAttachmentID", _s_set_BackAttachmentID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Vocation", _s_set_Vocation);
            
			XUtils.EndObjectRegister(typeof(xc.AvatarProperty), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.AvatarProperty), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.AvatarProperty));
			
			
			XUtils.EndClassRegister(typeof(xc.AvatarProperty), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<xc.AvatarProperty>(L, 2))
				{
					xc.AvatarProperty other = (xc.AvatarProperty)translator.GetObject(L, 2, typeof(xc.AvatarProperty));
					
					xc.AvatarProperty __cl_gen_ret = new xc.AvatarProperty(other);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.AvatarProperty __cl_gen_ret = new xc.AvatarProperty();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarProperty constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.AvatarProperty __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipModleIds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = __cl_gen_to_be_invoked.GetEquipModleIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFashionModleIds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = __cl_gen_to_be_invoked.GetFashionModleIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEquipPart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetEquipPart( part, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFashionPart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetFashionPart( part, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSuitEffectId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.AddSuitEffectId( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSuitEffectId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveSuitEffectId( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BodyId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.WeaponId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipBodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipBodyId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipWeaponId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionBodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionBodyId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionWeaponId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionWingId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionWingId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitEffectIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SuitEffectIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WingResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.WingResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ElfinId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ElfinId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ElfinResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ElfinResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionMagicalPetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionMagicalPetId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MagicalPetResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.MagicalPetResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionFootprintId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionFootprintId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionPhotoFrameId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionPhotoFrameId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FashionBubbleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FashionBubbleId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LightWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LightWeaponId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BackAttachmentID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BackAttachmentID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                translator.PushActorEVocationType(L, __cl_gen_to_be_invoked.Vocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BodyId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WeaponId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipBodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipBodyId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipWeaponId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionBodyId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionBodyId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionWeaponId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionWingId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionWingId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SuitEffectIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SuitEffectIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WingResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WingResPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ElfinId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ElfinId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ElfinResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ElfinResPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionMagicalPetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionMagicalPetId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MagicalPetResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MagicalPetResPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionFootprintId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionFootprintId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionPhotoFrameId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionPhotoFrameId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FashionBubbleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FashionBubbleId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LightWeaponId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LightWeaponId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BackAttachmentID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BackAttachmentID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarProperty __cl_gen_to_be_invoked = (xc.AvatarProperty)translator.FastGetCSObj(L, 1);
                Actor.EVocationType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Vocation = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
