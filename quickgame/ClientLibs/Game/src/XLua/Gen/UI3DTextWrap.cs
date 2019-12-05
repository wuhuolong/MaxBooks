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
    public class UI3DTextWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UI3DText), L, translator, 0, 17, 20, 24);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetStyleInfo", _m_ResetStyleInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetOwnerTrans", _m_SetOwnerTrans);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHeadTrans", _m_SetHeadTrans);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePosition", _m_UpdatePosition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutVisiable", _m_SetLayoutVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadSprite", _m_LoadSprite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDialogBubbleText", _m_SetDialogBubbleText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBGSprite", _m_SetBGSprite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBGMaterial", _m_SetBGMaterial);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowFrame", _m_ShowFrame);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowButton", _m_ShowButton);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetClickCallback", _m_SetClickCallback);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetButtonStyle", _m_SetButtonStyle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetButtonOffset", _m_SetButtonOffset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetActor", _m_SetActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowTeamIcon", _m_ShowTeamIcon);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowPeakTeamIcon", _m_ShowPeakTeamIcon);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Text", _g_get_Text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildNameTextLabel", _g_get_GuildNameTextLabel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateNameTextLabel", _g_get_MateNameTextLabel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RankTextLabel", _g_get_RankTextLabel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HangUpTextLabel", _g_get_HangUpTextLabel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Sprite", _g_get_Sprite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Offset", _g_get_Offset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ScreenOffset", _g_get_ScreenOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowBGSprite", _g_get_ShowBGSprite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowPreBGSprite", _g_get_ShowPreBGSprite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Position", _g_get_Position);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Trans", _g_get_Trans);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TextLabel", _g_get_TextLabel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TextColor", _g_get_TextColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Width", _g_get_Width);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Height", _g_get_Height);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Visible", _g_get_Visible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FontSize", _g_get_FontSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ButtonImage", _g_get_ButtonImage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HeadOffset", _g_get_HeadOffset);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Text", _s_set_Text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildNameTextLabel", _s_set_GuildNameTextLabel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MateNameTextLabel", _s_set_MateNameTextLabel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RankTextLabel", _s_set_RankTextLabel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HangUpTextLabel", _s_set_HangUpTextLabel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Honor", _s_set_Honor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Title", _s_set_Title);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpritName", _s_set_SpritName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Offset", _s_set_Offset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ScreenOffset", _s_set_ScreenOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowBGSprite", _s_set_ShowBGSprite);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowPreBGSprite", _s_set_ShowPreBGSprite);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowAffiliationPanel", _s_set_IsShowAffiliationPanel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowBar", _s_set_IsShowBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HpBarName", _s_set_HpBarName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BgPreHeadOffset", _s_set_BgPreHeadOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Position", _s_set_Position);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TextColor", _s_set_TextColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Scale", _s_set_Scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Width", _s_set_Width);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Height", _s_set_Height);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Visible", _s_set_Visible);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FontSize", _s_set_FontSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HeadOffset", _s_set_HeadOffset);
            
			XUtils.EndObjectRegister(typeof(UI3DText), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UI3DText), L, __CreateInstance, 1, 5, 5);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UI3DText));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NameTextScreenOffset", _g_get_NameTextScreenOffset);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "HpProgressScreenOffset", _g_get_HpProgressScreenOffset);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "LocalPlayerHpName", _g_get_LocalPlayerHpName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "FriendHpName", _g_get_FriendHpName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "EnemyHpName", _g_get_EnemyHpName);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "NameTextScreenOffset", _s_set_NameTextScreenOffset);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "HpProgressScreenOffset", _s_set_HpProgressScreenOffset);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "LocalPlayerHpName", _s_set_LocalPlayerHpName);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "FriendHpName", _s_set_FriendHpName);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "EnemyHpName", _s_set_EnemyHpName);
            
			XUtils.EndClassRegister(typeof(UI3DText), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UI3DText __cl_gen_ret = new UI3DText();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UI3DText constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetStyleInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UI3DText.StyleInfo>(L, 2)&& translator.Assignable<Actor>(L, 3)) 
                {
                    UI3DText.StyleInfo info = (UI3DText.StyleInfo)translator.GetObject(L, 2, typeof(UI3DText.StyleInfo));
                    Actor owner = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                    __cl_gen_to_be_invoked.ResetStyleInfo( info, owner );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UI3DText.StyleInfo>(L, 2)) 
                {
                    UI3DText.StyleInfo info = (UI3DText.StyleInfo)translator.GetObject(L, 2, typeof(UI3DText.StyleInfo));
                    
                    __cl_gen_to_be_invoked.ResetStyleInfo( info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UI3DText.ResetStyleInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOwnerTrans(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.SetOwnerTrans( trans );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHeadTrans(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.SetHeadTrans( trans );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePosition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.UpdatePosition(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    UnityEngine.Vector3 targetPosition;translator.Get(L, 2, out targetPosition);
                    UnityEngine.Vector3 offset;translator.Get(L, 3, out offset);
                    UnityEngine.Vector3 screenOffset;translator.Get(L, 4, out screenOffset);
                    
                    __cl_gen_to_be_invoked.UpdatePosition( targetPosition, offset, screenOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UI3DText.UpdatePosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetLayoutVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSprite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string spriteName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Sprite __cl_gen_ret = __cl_gen_to_be_invoked.LoadSprite( spriteName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDialogBubbleText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    int time = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.SetDialogBubbleText( text, time );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBGSprite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string spriteName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetBGSprite( spriteName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBGMaterial(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string materialName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetBGMaterial( materialName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowFrame(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    bool showPreBGSprite = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowFrame( isShow, showPreBGSprite );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowFrame( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UI3DText.ShowFrame!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowButton(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowButton( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetClickCallback(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Events.UnityAction clickCallback = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetClickCallback( clickCallback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetButtonStyle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string buttonSpriteName = LuaAPI.lua_tostring(L, 2);
                    string buttonText = LuaAPI.lua_tostring(L, 3);
                    int buttonTextFontSize = LuaAPI.xlua_tointeger(L, 4);
                    UnityEngine.Color buttonTextColor;translator.Get(L, 5, out buttonTextColor);
                    UnityEngine.Vector3 buttonTextOffset;translator.Get(L, 6, out buttonTextOffset);
                    
                    __cl_gen_to_be_invoked.SetButtonStyle( buttonSpriteName, buttonText, buttonTextFontSize, buttonTextColor, buttonTextOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetButtonOffset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 offset;translator.Get(L, 2, out offset);
                    
                    __cl_gen_to_be_invoked.SetButtonOffset( offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor owner = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                    __cl_gen_to_be_invoked.SetActor( owner );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTeamIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string spriteName = LuaAPI.lua_tostring(L, 2);
                    bool isShow = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowTeamIcon( spriteName, isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowPeakTeamIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowPeakTeamIcon( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildNameTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GuildNameTextLabel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateNameTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.MateNameTextLabel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RankTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RankTextLabel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HangUpTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.HangUpTextLabel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Sprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Sprite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Offset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.Offset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ScreenOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowBGSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowBGSprite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowPreBGSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowPreBGSprite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Position(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.Position);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Trans(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Trans);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TextLabel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, __cl_gen_to_be_invoked.TextColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Width);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Height);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Visible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Visible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.FontSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ButtonImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ButtonImage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NameTextScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineVector3(L, UI3DText.NameTextScreenOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HpProgressScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineVector3(L, UI3DText.HpProgressScreenOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerHpName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UI3DText.LocalPlayerHpName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FriendHpName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UI3DText.FriendHpName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnemyHpName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UI3DText.EnemyHpName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.HeadOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildNameTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildNameTextLabel = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MateNameTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MateNameTextLabel = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RankTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RankTextLabel = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HangUpTextLabel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HangUpTextLabel = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Honor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Title = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpritName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SpritName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Offset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Offset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ScreenOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowBGSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowBGSprite = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowPreBGSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowPreBGSprite = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowAffiliationPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowAffiliationPanel = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HpBarName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HpBarName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BgPreHeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.BgPreHeadOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Position(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Position = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Color __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.TextColor = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Scale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Width = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Height = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Visible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Visible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FontSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NameTextScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				UI3DText.NameTextScreenOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HpProgressScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				UI3DText.HpProgressScreenOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerHpName(RealStatePtr L)
        {
            
            try {
			    UI3DText.LocalPlayerHpName = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FriendHpName(RealStatePtr L)
        {
            
            try {
			    UI3DText.FriendHpName = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnemyHpName(RealStatePtr L)
        {
            
            try {
			    UI3DText.EnemyHpName = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText __cl_gen_to_be_invoked = (UI3DText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.HeadOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
