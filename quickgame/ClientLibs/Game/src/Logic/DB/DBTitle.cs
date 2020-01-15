using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine.UI;

namespace xc
{
    public class DBTitle : DBSqliteTableResource
    {
        public class DBTitleItem
        {
            public uint Id; //称号表id字段
            public uint Quality; //品质
            public string Name; // 称号名
            public uint SortId;
            public uint PageType;
            public uint Type; // 称号类型（1，永久；2，限时）
            public bool IgnoreNewTitle;
            public uint Time;
            public string Icon; // 称号图标名
            public uint EffectId; // 特效id
            public string GetCondition;
            public string TimeDesc; // 有效时间描述, 称号类型等于1的时候才生效
            public List<DBTextResource.DBAttrItem> CollectAttr;
            public List<DBTextResource.DBAttrItem> WearAttr;
        }

        public Dictionary<uint, DBTitleItem> Data = new Dictionary<uint, DBTitleItem>();

        public DBTitle(string strName, string strPath) : base(strName, strPath)
        {

        }

        public DBTitleItem GetData(uint id)
        {
            DBTitleItem ad = null;
            Data.TryGetValue(id, out ad);
            return ad;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBTitleItem ad = new DBTitleItem();
                ad.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                ad.Name = GetReaderString(reader, "name");
                ad.Icon = GetReaderString(reader, "icon_name");
                ad.EffectId = DBTextResource.ParseUI(GetReaderString(reader, "effect_id"));
                ad.GetCondition = GetReaderString(reader, "get_condition");
                ad.TimeDesc = GetReaderString(reader, "time_desc");
                ad.SortId = DBTextResource.ParseUI(GetReaderString(reader, "sort_id"));
                ad.PageType = DBTextResource.ParseUI(GetReaderString(reader, "page"));
                ad.Type = DBTextResource.ParseUI(GetReaderString(reader, "type"));
                ad.IgnoreNewTitle = DBTextResource.ParseUI_s(GetReaderString(reader, "ignore_new_title"), 0) == 1;
                ad.Time = DBTextResource.ParseUI(GetReaderString(reader, "time"));
                ad.CollectAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "collect_attr"));
                ad.WearAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "wear_attr"));
                ad.Quality = DBTextResource.ParseUI_s(GetReaderString(reader, "quality"), 0);
                Data.Add(ad.Id, ad);
            }
        }

        public override void Unload()
        {
            Data.Clear();
        }

        public string GetTitleIcon()
        {
            return GetTitleIcon(LocalPlayerManager.Instance.LocalActorAttribute.Title);
        }

        public string GetTitleIcon(uint titleId)
        {
            var item = GetData(titleId);
            if (null == item || item.Icon.Length <= 0)
                return null;

            return item.Icon;
        }

        public void SetTitleEffect(uint titleId, RawImage rawImg)
        {
            if (null == rawImg)
                return;

            // 低配下不使用称号特效
            if (QualitySetting.GraphicLevel == (int)EGraphLevel.LOW)
            {
                rawImg.gameObject.SetActive(false);
                rawImg.texture = null;
                return;
            }

            var dbTitleItem = GetData(titleId);
            if (null == dbTitleItem)
            {
                rawImg.gameObject.SetActive(false);
                rawImg.texture = null;
                return;
            }

            var effectInfo = xc.DBManager.Instance.GetDB<xc.DBTitleEffect>().GetData(dbTitleItem.EffectId);
            if (null == effectInfo)
            {
                rawImg.gameObject.SetActive(false);
                rawImg.texture = null;
                return;
            }

            string effectName = effectInfo.Name; // **.png

            // 当前特效名
            string curEffectName = null;
            if (rawImg.texture != null)
            {
                curEffectName = string.Format("{0}.png", rawImg.texture.name);

                if (curEffectName.Equals(effectName))
                {
                    rawImg.gameObject.SetActive(true);
                    return;
                }
            }

            rawImg.gameObject.SetActive(false);

            var effectImagePath = string.Format("Assets/Res/Effects/Textures/{0}", effectInfo.Name);

            SGameEngine.ResourceLoader.Instance.LoadAssetAsync(effectImagePath, (asset_res) =>
            {
                Texture effectTexture = asset_res.asset_ as Texture;
                if (effectTexture != null)
                {
                    if (null == rawImg || rawImg.IsDestroyed() || !rawImg.transform.parent.gameObject.activeSelf)
                    {
                        if (asset_res != null)
                        {
                            asset_res.destroy();
                            asset_res = null;
                        }
                    }
                    else
                    {
                        rawImg.gameObject.SetActive(true);
                        rawImg.texture = effectTexture;

                        // 设置大小
                        var rt = rawImg.GetComponent<RectTransform>();
                        if (rt != null)
                        {
                            rt.sizeDelta = effectInfo.FrameSize;
                        }

                        var frameCom = rawImg.transform.GetComponent<UGUIFrameAnimation>();
                        if (frameCom != null)
                        {
                            uint col = (uint)effectInfo.Arg.x;
                            uint row = (uint)effectInfo.Arg.y;

                            if (col > 0 && row > 0)
                            {
                                frameCom.enabled = false;

                                frameCom.FrameCount = 16;
                                frameCom.OneFrameWidth = 1f / col;
                                frameCom.OneFrameHeight = 1f / row;
                                frameCom.RectXSpace = 1f / col;
                                frameCom.RectYSpace = 1f / row;
                                frameCom.ColNum = col;
                                frameCom.FrameInterval = 0.05f;
                                frameCom.IsLoop = true;
                                frameCom.StartFrame = 0;

                                frameCom.enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    if (asset_res != null)
                    {
                        asset_res.destroy();
                        asset_res = null;
                    }
                }
            });
        }
    }
}