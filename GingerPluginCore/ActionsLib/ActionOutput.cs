#region License
/*
Copyright © 2014-2018 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion


using System.Collections.Generic;
using System.Linq;

namespace GingerPlugInsNET.ActionsLib
{
    public class ActionOutput
    {
        public List<ActionOutputValue> Values = new List<ActionOutputValue>();

        public void Add(string key, string value, string path = null)
        {
            Values.Add(new ActionOutputValue() { Param = key, ValueString = value, Path = path });
        }

        public void Add(string key, byte[] value, string path = null)
        {
            Values.Add(new ActionOutputValue() { Param = key, ValueByteArray = value, Path = path });
        }
        
        public string this[string key]
        {
            get
            {
                return (from x in Values where x.Param == key select x.ValueString).FirstOrDefault();       
            }
        }

        public byte[] getBytes(string key)
        {            
            return (from x in Values where x.Param == key select x.ValueByteArray).FirstOrDefault();                        
        }
    }
}
