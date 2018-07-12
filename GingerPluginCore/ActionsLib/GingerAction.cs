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

namespace GingerPlugInsNET.ActionsLib
{
    public class GingerAction
    {
        public string ID { get; set; }

        public ActionInputParams InputParams = new ActionInputParams();

        public ActionOutput Output = new ActionOutput();        

        public GingerAction(string Id)
        {
            ID = Id;
        }

        public string ExInfo { get; set; }

        // Keep it private so code must use AddError, and errors are added formatted
        private string mErrors { get; set; }

        // We can create better nice error
        public void AddError(string source, string err)
        {
            // DateTime.Now  // add tomestamp
            if (!string.IsNullOrEmpty(mErrors))
            {
                mErrors += Environment.NewLine;
            }
            mErrors += err;
        }

        /// <summary>
        /// Return errors all errors colelcted as string
        /// </summary>
        public string Errors
        {
            get
            {
                return mErrors;
            }
        }
    }
}
