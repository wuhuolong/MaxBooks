using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBModel : DBSqliteTableResource
    {
        private Dictionary<uint, ModelInfo> mModels = new Dictionary<uint, ModelInfo>();

        public DBModel(string strName, string strPath) : base(strName,strPath)
        {
            
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mModels.Clear();
        }

        /// <summary>
        /// 根据id得到模型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModelInfo GetModel(uint id)
        {
            ModelInfo info;
            if (mModels.TryGetValue(id, out info))
            {
                return info;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mModels[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mModels[id] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            string model = GetReaderString(reader, "model");
            string ui_model = GetReaderString(reader, "ui_model");
            string icon = GetReaderString(reader, "icon");
            float scale = DBTextResource.ParseF_s(GetReaderString(reader, "scale"), 0f);
            Vector3 posOffsetInScene = DBTextResource.ParseVector3(GetReaderString(reader, "pos_offset_in_scene"));
            Vector3 camOffsetInDialogWnd = DBTextResource.ParseVector3(GetReaderString(reader, "cam_offset_in_dialog_wnd"));
            Vector3 camRotateInDialogWnd = DBTextResource.ParseVector3(GetReaderString(reader, "cam_rotate_in_dialog_wnd"));
            Vector3 modelOffsetInChipWin = DBTextResource.ParseVector3(GetReaderString(reader, "model_offset_in_chip_win"));
            Vector3 modelAngleInChipWin = DBTextResource.ParseVector3(GetReaderString(reader, "model_angle_in_chip_win"));
            string modelShowAction = GetReaderString(reader, "model_show_action");

            info = new ModelInfo(id, model, ui_model, icon, scale, posOffsetInScene,
                                camOffsetInDialogWnd, camRotateInDialogWnd,
                                modelOffsetInChipWin, modelAngleInChipWin, modelShowAction);

            mModels.Add(info.Id, info);

            reader.Close();
            reader.Dispose();

            return info;
        }
    }
}