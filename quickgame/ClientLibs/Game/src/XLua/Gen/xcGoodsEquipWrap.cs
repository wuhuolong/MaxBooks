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
    public class xcGoodsEquipWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsEquip), L, translator, 0, 9, 36, 17);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateGem", _m_UpdateGem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAttr", _m_UpdateAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHasIdentifyWing", _m_IsHasIdentifyWing);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateGoodsByTypeId", _m_CreateGoodsByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshEquipUp", _m_RefreshEquipUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ParseClientGoodsStr_inner", _m_ParseClientGoodsStr_inner);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetClientGoodsStr_inner", _m_GetClientGoodsStr_inner);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "can_use", _g_get_can_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxStrengthLv", _g_get_MaxStrengthLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInstalled", _g_get_IsInstalled);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInstalledByOtherPlayer", _g_get_IsInstalledByOtherPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsGem", _g_get_IsGem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWeapon", _g_get_IsWeapon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Data", _g_get_Data);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipPos", _g_get_EquipPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Index", _g_get_Index);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Star", _g_get_Star);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DefaultExtraDesc", _g_get_DefaultExtraDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BasicAttrs", _g_get_BasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrs", _g_get_LegendAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExtraAttrs", _g_get_ExtraAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaptizeAttrs", _g_get_BaptizeAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitInfo", _g_get_SuitInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitId", _g_get_SuitId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SuitLv", _g_get_SuitLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RefineLv", _g_get_RefineLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LegendAttrsDefaultScore", _g_get_LegendAttrsDefaultScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipRank", _g_get_EquipRank);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrenghtLv", _g_get_StrenghtLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Rank", _g_get_Rank);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Rank_CheckExpireTime", _g_get_Rank_CheckExpireTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CastSoulLv", _g_get_CastSoulLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OrigName", _g_get_OrigName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "raw_name", _g_get_raw_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preview_raw_name", _g_get_preview_raw_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelId", _g_get_ModelId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NetEquip", _g_get_NetEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExtendPropertys", _g_get_ExtendPropertys);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Gems", _g_get_Gems);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerStar", _g_get_ServerStar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerEquipRank", _g_get_ServerEquipRank);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "can_use", _s_set_can_use);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsInstalledByOtherPlayer", _s_set_IsInstalledByOtherPlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LegendAttrs", _s_set_LegendAttrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExtraAttrs", _s_set_ExtraAttrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SuitLv", _s_set_SuitLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RefineLv", _s_set_RefineLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrenghtLv", _s_set_StrenghtLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CastSoulLv", _s_set_CastSoulLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OrigName", _s_set_OrigName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "raw_name", _s_set_raw_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "preview_raw_name", _s_set_preview_raw_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NetEquip", _s_set_NetEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExtendPropertys", _s_set_ExtendPropertys);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Gems", _s_set_Gems);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerStar", _s_set_ServerStar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerEquipRank", _s_set_ServerEquipRank);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsEquip), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsEquip), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsEquip));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsEquip), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsEquip __cl_gen_ret = new xc.GoodsEquip();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Net.PkgGoodsInfo>(L, 3))
				{
					uint typeId = LuaAPI.xlua_touint(L, 2);
					Net.PkgGoodsInfo equip = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
					
					xc.GoodsEquip __cl_gen_ret = new xc.GoodsEquip(typeId, equip);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsEquip constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.PkgGoodsInfo equip = (Net.PkgGoodsInfo)translator.GetObject(L, 2, typeof(Net.PkgGoodsInfo));
                    
                    __cl_gen_to_be_invoked.UpdateGem( equip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    Net.PkgGoodsInfo equip = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
                    
                    __cl_gen_to_be_invoked.UpdateAttr( gid, equip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHasIdentifyWing(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHasIdentifyWing(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.CreateGoodsByTypeId( gid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsEquip __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshEquipUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshEquipUp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseClientGoodsStr_inner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.Dictionary<string, string> param_dict = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
                    
                    __cl_gen_to_be_invoked.ParseClientGoodsStr_inner( param_dict );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClientGoodsStr_inner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Text.StringBuilder builder = (System.Text.StringBuilder)translator.GetObject(L, 2, typeof(System.Text.StringBuilder));
                    
                    __cl_gen_to_be_invoked.GetClientGoodsStr_inner( ref builder );
                    translator.Push(L, builder);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.can_use);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxStrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxStrengthLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInstalled(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInstalled);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInstalledByOtherPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInstalledByOtherPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsGem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsGem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWeapon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWeapon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Data);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EquipPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Index);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Star(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Star);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultExtraDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DefaultExtraDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BasicAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BasicAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LegendAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtraAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ExtraAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaptizeAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaptizeAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SuitInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SuitId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SuitLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SuitLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RefineLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RefineLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegendAttrsDefaultScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LegendAttrsDefaultScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipRank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.EquipRank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrenghtLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrenghtLv);
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
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Rank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Rank_CheckExpireTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Rank_CheckExpireTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CastSoulLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CastSoulLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OrigName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.OrigName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.raw_name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preview_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.preview_raw_name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ModelId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NetEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NetEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtendPropertys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ExtendPropertys);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gems(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Gems);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerStar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerEquipRank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ServerEquipRank);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.can_use = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsInstalledByOtherPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsInstalledByOtherPlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LegendAttrs = (xc.Equip.EquipAttributes)translator.GetObject(L, 2, typeof(xc.Equip.EquipAttributes));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExtraAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExtraAttrs = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SuitLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SuitLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RefineLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RefineLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrenghtLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrenghtLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CastSoulLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CastSoulLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OrigName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OrigName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.raw_name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preview_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.preview_raw_name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NetEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NetEquip = (Net.PkgGoodsInfo)translator.GetObject(L, 2, typeof(Net.PkgGoodsInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExtendPropertys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExtendPropertys = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Gems(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Gems = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerStar = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerEquipRank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsEquip __cl_gen_to_be_invoked = (xc.GoodsEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerEquipRank = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
