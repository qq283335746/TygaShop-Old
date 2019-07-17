using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetSoft.BLL
{
    [Serializable]
    public class UserCustomAttr
    {
        private List<Model.UserCustomAttr> list = new List<Model.UserCustomAttr>();

        public void Insert(Model.UserCustomAttr model)
        {
            if (!list.Contains(model))
            {
                list.Add(model);
            }
        }

        public void Update(Model.UserCustomAttr model)
        {
            int i = list.FindIndex(delegate(Model.UserCustomAttr m) { return m == model; });
            if (i >= 0)
            {
                list.IndexOf(model, i);
            }
        }

        public List<Model.UserCustomAttr> GetList()
        {
            return list;
        }

        public Model.UserCustomAttr GetModel(Model.UserCustomAttr model)
        {
            return list.Find(delegate(Model.UserCustomAttr m) { return m == model; });
        }

        public int Count
        {
            get { return list.Count(); }
        }

        public void Remove(Model.UserCustomAttr model)
        {
            list.RemoveAll(delegate(Model.UserCustomAttr m) { return m == model; });
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
