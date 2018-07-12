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
using System.Linq;
using System.Reflection;

namespace GingerPlugInsNET.ActionsLib
{
    public class ActionRunner
    {
        // Action running the action can be on driver or standalone actions class
        public static void RunAction(object obj, GingerAction GA, ActionHandler AH)  // TODO: maybe need to pass only the AH with all data inside
        {            
            try
            {
                if (AH != null)
                {
                    ParameterInfo[] PIs = AH.MethodInfo.GetParameters();

                    object[] parameters = new object[PIs.Count()];

                    int paramnum = 0;
                    foreach (ParameterInfo PI in PIs)
                    {
                        if (paramnum == 0)
                        {
                            // verify param 0 is GA
                            parameters[0] = GA;
                        }
                        else
                        {
                            object ActionParam = GA.InputParams[PI.Name];
                            if (ActionParam != null)
                            {
                                object val = null;
                                // For each type we need to get the val correctly so the function will get it right
                                if (PI.ParameterType.IsEnum)
                                {
                                    if (GA.InputParams[PI.Name].Value != null)
                                    {
                                        val = Enum.Parse(PI.ParameterType, GA.InputParams[PI.Name].Value.ToString());
                                    }
                                    else
                                    {
                                        // TODO: err or check if it is nullable enum
                                    }
                                }
                                else if (PI.ParameterType == typeof(Int32))
                                {
                                    val = GA.InputParams[PI.Name].GetValueAsInt();
                                }
                                //TODO: handle all types
                                else
                                {
                                    val = GA.InputParams[PI.Name].Value;
                                }

                                parameters[paramnum] = val;
                            }
                            else
                            {
                                //check if param is optional then ignore
                                if (!PI.HasDefaultValue)
                                {
                                    throw new Exception("GingerAction is Missing Param/Value for ActionParam - " + PI.Name);
                                }
                                else
                                {
                                    // from here on all params are optional...
                                }
                            }
                        }
                        paramnum++;
                    }
                    AH.MethodInfo.Invoke(obj, parameters);   // here is where we call the action directly with the relevant parameters
                }
                else
                {
                    throw new Exception("Run Action failed because class doesn't contain method action with ID: " + GA.ID);
                }
            }
            catch (Exception ex)
            {
                GA.AddError("RunAction", "Error when trying to invoke: " + AH.ID + " - " + ex.Message);
            }
        }
    }
}