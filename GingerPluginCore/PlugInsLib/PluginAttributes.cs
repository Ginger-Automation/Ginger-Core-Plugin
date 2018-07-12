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

using System;

namespace GingerPlugInsNET.PlugInsLib
{
    // Annotation of [GingerAction] for function in driver we want to use as actions
    public class GingerActionAttribute : Attribute
    {
        string mID;
        string mDescription;

        // ID is kemp in the XML and should never changed!
        // Description is displayed to the user when he select action to add
        public GingerActionAttribute(string ID, string Description)
        {
            mID = ID;
            mDescription = Description;
        }

        public string ID {get {return mID; } set { mID = value; }  }
        public string Description { get { return mDescription; } set { mDescription = value; } }

        public override string ToString()
        {
            return "GingerAction";
        }
    }
}
