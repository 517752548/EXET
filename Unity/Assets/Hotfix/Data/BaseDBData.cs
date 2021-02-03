using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UltraLiteDB;
using UnityEngine;

namespace ETHotfix
{
    public class BaseDBData
    {
        public BsonDocument ToBsonDocument()
        {
            var character2 = new BsonDocument();
            Type t = this.GetType();//获得该类的Type

            //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
            foreach (PropertyInfo pi in t.GetProperties())
            {
                object value1 = pi.GetValue(this, null);//用pi.GetValue获得值
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                
                if(value1.GetType() == typeof(int))
                {
                    character2[name] = (int)value1;
                }
                if(value1.GetType() == typeof(string))
                {
                    character2[name] = (string)value1;
                }
            }
            return character2;
        }

        public void SetBsonDocument(BsonDocument _BsonDocument)
        {
            Type t = this.GetType();//获得该类的Type
            foreach (PropertyInfo pi in t.GetProperties())
            {
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                if (_BsonDocument.Keys.Contains(name))
                {
                    if(_BsonDocument[name].GetType() == typeof(int))
                    {
                        pi.SetValue(this,_BsonDocument[name].AsInt32);
                    }
                    if(_BsonDocument[name].GetType() == typeof(string))
                    {
                        pi.SetValue(this,_BsonDocument[name].AsString);
                    }
                }
            }
        }
    }
}