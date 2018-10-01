using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetSoft.BLL
{
    [Serializable]
    public class UserAddress
    {
        private List<Model.UserAddress> list = new List<Model.UserAddress>();

        public void Insert(Model.UserAddress model)
        {
            if (!list.Contains(model))
            {
                list.Add(model);
            }
        }

        public void Update(Model.UserAddress model)
        {
            int i = list.FindIndex(delegate(Model.UserAddress m) { return m.NumberID == model.NumberID; });
            if (i >= 0)
            {
                list.IndexOf(model, i);
            }
        }

        public List<Model.UserAddress> GetList()
        {
            return list;
        }

        public Model.UserAddress GetModel(Guid numberId)
        {
            return list.Find(delegate(Model.UserAddress m) { return m.NumberID == numberId; });
        }

        public int Count
        {
            get { return list.Count(); }
        }

        public void Remove(Guid numberId)
        {
            list.RemoveAll(delegate(Model.UserAddress m) { return m.NumberID == numberId; });
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
